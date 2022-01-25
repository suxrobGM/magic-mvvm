using MagicMvvm.AppModel;
using MagicMvvm.Dialogs.Xaml;
using MagicMvvm.Helpers;
using Microsoft.Maui.Layouts;

namespace MagicMvvm.Dialogs;

/// <summary>
/// Provides the ability to display dialogs from ViewModels.
/// </summary>
public sealed class DialogManager : IDialogManager
{
    private readonly IDictionary<string, Type> _dialogs;
    private readonly IAppProvider _appProvider;

    /// <summary>
    /// Gets the key for specifying or retrieving popup overlay style from Application Resources.
    /// </summary>
    public const string PopupOverlayStyle = "DialogMaskStyle";

    /// <summary>
    /// Initializes a new instance of the <see cref="DialogManager"/> class.
    /// </summary>
    public DialogManager(IAppProvider appProvider)
    {
        _appProvider = appProvider;
        _dialogs = new Dictionary<string, Type>();
    }

    public IDialogManager RegisterDialog<T>(string dialogName) where T : View
    {
        if (string.IsNullOrEmpty(dialogName))
            throw new ArgumentNullException(nameof(dialogName));

        _dialogs.Add(dialogName, typeof(T));
        return this;
    }

    public void ShowDialog(string dialogName, IParameters parameters, Action<IDialogResult> callback)
    {
        try
        {
            parameters = UriHelper.GetSegmentParameters(dialogName, parameters);

            var view = CreateViewFor(UriHelper.GetSegmentName(dialogName));
            var dialogAware = InitializeDialog(view, parameters);
            var currentPage = GetCurrentContentPage();

            var dialogModal = new DialogHostPage();
            dialogAware.RequestClose += DialogAware_RequestClose;

            async void DialogAware_RequestClose(IParameters outParameters)
            {
                try
                {
                    var result = await CloseDialogAsync(outParameters ?? new Parameters(), currentPage, dialogModal);
                    dialogModal.RaiseDialogResult(result);
                    if (result.Exception is DialogException { Message: DialogException.CanCloseIsFalse })
                    {
                        return;
                    }

                    dialogAware.RequestClose -= DialogAware_RequestClose;
                    callback?.Invoke(result);
                    GC.Collect();
                }
                catch (DialogException dex)
                {
                    var result = new DialogResult
                    {
                        Exception = dex,
                        Parameters = parameters
                    };
                    dialogModal.RaiseDialogResult(result);

                    if (dex.Message != DialogException.CanCloseIsFalse)
                    {
                        callback?.Invoke(result);
                    }
                }
                catch (Exception ex)
                {
                    var result = new DialogResult
                    {
                        Exception = ex,
                        Parameters = parameters
                    };
                    dialogModal.RaiseDialogResult(result);
                    callback?.Invoke(result);
                }
            }

            if (!parameters.TryGetValue<bool>(KnownDialogParameters.CloseOnBackgroundTapped, out var closeOnBackgroundTapped))
            {
                var dialogLayoutCloseOnBackgroundTapped = DialogLayout.GetCloseOnBackgroundTapped(view);
                if (dialogLayoutCloseOnBackgroundTapped.HasValue)
                {
                    closeOnBackgroundTapped = dialogLayoutCloseOnBackgroundTapped.Value;
                }
            }

            InsertPopupViewInCurrentPage(currentPage, dialogModal, view, closeOnBackgroundTapped, DialogAware_RequestClose);
        }
        catch (Exception ex)
        {
            callback?.Invoke(new DialogResult { Exception = ex });
        }
    }

    private async Task<IDialogResult> CloseDialogAsync(IParameters parameters, ContentPage currentPage, IDialogContainer dialogModal)
    {
        try
        {
            //PageNavigationService.NavigationSource = PageNavigationSource.DialogService;

            parameters ??= new Parameters();
            var dialogAware = GetDialogAware(dialogModal.DialogView);

            if (!dialogAware.CanCloseDialog())
            {
                throw new DialogException(DialogException.CanCloseIsFalse);
            }

            await currentPage.Navigation.PopModalAsync(true);
            dialogAware.OnDialogClosed();

            return new DialogResult
            {
                Parameters = parameters
            };
        }
        catch (DialogException)
        {
            throw;
        }
        catch (Exception ex)
        {
            return new DialogResult
            {
                Exception = ex,
                Parameters = parameters
            };
        }
        // finally
        // {
        //     PageNavigationService.NavigationSource = PageNavigationSource.Device;
        // }
    }

    private View CreateViewFor(string dialogName)
    { 
        var view = _appProvider.ServiceProvider.GetRequiredService(_dialogs[dialogName]) as View;
        return view;
    }

    private IDialogAware GetDialogAware(View view)
    {
        if (view is IDialogAware viewAsDialogAware)
        {
            return viewAsDialogAware;
        }

        return view.BindingContext switch
        {
            null => throw new DialogException(DialogException.NoViewModel),
            IDialogAware dialogAware => dialogAware,
            _ => throw new DialogException(DialogException.ImplementIDialogAware)
        };
    }

    private IDialogAware InitializeDialog(View view, IParameters parameters)
    {
        var dialogAware = GetDialogAware(view);
        dialogAware?.OnDialogOpened(parameters);
        return dialogAware;
    }

    private ContentPage GetCurrentContentPage()
    {
        var currentPage = GetCurrentPage();
        var modalPage = TryGetModalPage(currentPage);
        return modalPage ?? currentPage;
    }

    private ContentPage TryGetModalPage(ContentPage cp)
    {
        var mp = cp.Navigation.ModalStack.LastOrDefault();
        return mp != null ? GetCurrentPage(mp) : null;
    }

    private ContentPage GetCurrentPage(Page page = null)
    {
        while (true)
        {
            switch (page)
            {
                case ContentPage cp:
                {
                    return cp;
                }
                case TabbedPage tp:
                {
                    page = tp.CurrentPage;
                    continue;
                }
                case NavigationPage np:
                {
                    page = np.CurrentPage;
                    continue;
                }
                case CarouselPage carouselPage:
                {
                    page = carouselPage.CurrentPage;
                    continue;
                }
                case FlyoutPage flyout:
                {
                    flyout.IsPresented = false;
                    page = flyout.Detail;
                    continue;
                }

                case Shell shell:
                {
                    page = (shell.CurrentItem.CurrentItem as IShellSectionController).PresentedPage;
                    continue;
                }
                default:
                {
                    // If we get some random Page Type
                    if (page != null)
                    {
                        // TODO: add log
                        //Microsoft.Maui.Internals.Log.Warning("Warning",
                        //    $"An Unknown Page type {page.GetType()} was found walk walking the Navigation Stack. This is not supported by the DialogManager");
                        return null;
                    }

                    var mainPage = _appProvider.MainPage;
                    if (mainPage is null)
                        return null;

                    page = mainPage;
                    continue;
                }
            }
        }
    }

    private async void InsertPopupViewInCurrentPage(ContentPage currentPage,
        DialogHostPage modalPage,
        View popupView,
        bool hideOnBackgroundTapped,
        Action<IParameters> callback)
    {
        var mask = DialogLayout.GetMask(popupView);

        if (mask is null)
        {
            var overlayStyle = GetOverlayStyle(popupView);

            mask = new BoxView
            {
                Style = overlayStyle
            };
        }

        mask.SetBinding(VisualElement.WidthRequestProperty, new Binding { Path = "Width", Source = modalPage });
        mask.SetBinding(VisualElement.HeightRequestProperty, new Binding { Path = "Height", Source = modalPage });

        var dismissCommand = new Command(() => callback(new Parameters()));
        if (hideOnBackgroundTapped)
        {
            mask.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = dismissCommand
            });
        }
        modalPage.Dismiss = dismissCommand;

        var overlay = new AbsoluteLayout();
        var popupContainer = new DialogContainer
        {
            IsPopupContent = true,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Content = popupView,
        };

        var relativeWidth = DialogLayout.GetRelativeWidthRequest(popupView);
        if (relativeWidth != null)
        {
            popupContainer.SetBinding(DialogContainer.WidthRequestProperty,
                new Binding("Width",
                            BindingMode.OneWay,
                            new RelativeContentSizeConverter { RelativeSize = relativeWidth.Value },
                            source: modalPage));
        }

        var relativeHeight = DialogLayout.GetRelativeHeightRequest(popupView);
        if (relativeHeight != null)
        {
            popupContainer.SetBinding(DialogContainer.HeightRequestProperty,
                new Binding("Height",
                            BindingMode.OneWay,
                            new RelativeContentSizeConverter { RelativeSize = relativeHeight.Value },
                            source: modalPage));
        }

        AbsoluteLayout.SetLayoutFlags(popupContainer, AbsoluteLayoutFlags.PositionProportional);
        var popupBounds = DialogLayout.GetLayoutBounds(popupView);
        AbsoluteLayout.SetLayoutBounds(popupContainer, popupBounds);

        if (DialogLayout.GetUseMask(popupContainer.Content) ?? true)
        {
            overlay.Children.Add(mask);
        }

        overlay.Children.Add(popupContainer);

        modalPage.Content = overlay;
        modalPage.DialogView = popupView;
        await currentPage.Navigation.PushModalAsync(modalPage, true);
    }

    private static Style GetOverlayStyle(View popupView)
    {
        var style = DialogLayout.GetMaskStyle(popupView);
        if (style != null)
        {
            return style;
        }

        if (Application.Current.Resources.ContainsKey(PopupOverlayStyle))
        {
            style = (Style)Application.Current.Resources[PopupOverlayStyle];
            if (style.TargetType == typeof(BoxView))
            {
                return style;
            }
        }

        var overlayStyle = new Style(typeof(BoxView));
        overlayStyle.Setters.Add(new Setter { Property = VisualElement.OpacityProperty, Value = 0.75 });
        overlayStyle.Setters.Add(new Setter { Property = VisualElement.BackgroundColorProperty, Value = Colors.Black });

        Application.Current.Resources[PopupOverlayStyle] = overlayStyle;
        return overlayStyle;
    }
}