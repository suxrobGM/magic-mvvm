# MagicMvvm
MagicMvvm is lightweight library for building rapid MVVM applications. Project inspired from [Prism](https://github.com/PrismLibrary/Prism) and used the best Prism practices, and made a lightweight library. The main difference from Prism is that supporting any IoC container (IoC container agnostic). You can use this library with any IoC container.
Currently only WPF platform is supported.

## Features
* IoC container agnostic.
* Dynamic navigation between various views.
* Dialog navigation.
* Passing parameters to dialogs.
* Passing parameters to navigable view models.
* Result of navigation operation.
* View model closing handling.
* Handling view models navigation lifecycle.
* Update commands on property changed.

## NuGet packages

| Platform | Package | NuGet | 
| -------- | ------- | ------- |
| Cross Platform | [MagicMvvm.Core][CoreNuGet] | [![CoreNuGetShield]][CoreNuGet] | 
| WPF | [MagicMvvm.Wpf][WpfNuGet] | [![WpfNuGetShield]][WpfNuGet] | 


## Installation
Just grab it from [NuGet](https://www.nuget.org/packages/MagicMvvm.Wpf/)

```
PM> Install-Package MagicMvvm.Wpf
```

```
$ dotnet add package MagicMvvm.Wpf
```


## Getting Started
### Prepare application startup class
Install nuget package then navigate to `App.xaml` and remove line which starts with `StartupUri` 
```xml
<Application x:Class="SampleWpf.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:SampleWpf">
             <Application.Resources>  
             </Application.Resources>
</Application>
```

Override `OnStartup` method in `App.xaml.cs` then create object of main view (usually it is `MainWindow`) or you can resolve it if you use container.

Example code without container support.
```csharp
public partial class App : Application
{    
    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = new MainWindow(new MainWindowViewModel());
        mainWindow.Show();
        base.OnStartup(e);
    }
}
```

Example code with container support. Used [DryIoc](https://github.com/dadhi/DryIoc) container.
```csharp
public partial class App : Application
{    
    public static readonly IContainer Container = new Container();

    protected override void OnStartup(StartupEventArgs e)
    {
        RegisterTypes();

        var mainWindow = Container.Resolve<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }

    // Register all types inside this method
    protected virtual void RegisterTypes()
    {
        // Register views
        Container.Register<MainWindow>(Reuse.Singleton);

        // Register view models
        Container.Register<MainWindowViewModel>(Reuse.Singleton);
    }
}
```

### View models

Create view model class then inherit abstract class `ViewModelBase`
Inside `ViewModelBase` defined set of methods such as a `SetProperty()`
`SetProperty()` method changes value of backing field then raises propery changed event. 

```csharp
public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Message = "Welcome to MagicMvvm";
    }

    private string _message;
    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value); // Raises on property changed event
    }
}
```

### Binding view models to view
Example code demonstrates binding view model of `MainWindow` without contianer support.

```csharp
// MainWindow.xaml.cs file
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}
```

If you use container then you need to do a bit extra work. Due to IoC container agnostic feature, injecting types inside constructor of the view object is NOT supported. In order to bind view model to view object, you need to create static instance of container in `App.xaml.cs` then resolve view model objects inside view constructor.
Below sample code demonstrates this approach.

```csharp
// MainWindow.xaml.cs file
public partial class MainWindow : Window
{
    // It is important to keep parameterless constructor of view object, if you use IoC container.
    // This restriction applicable only for view objects.
    public MainWindow()
    {
        // Resolve view model then bind to data context
        DataContext = App.Container.Resolve<MainWindowViewModel>(); 
        InitializeComponent();
    }
}
```

## Samples
Check out sample applications [here](https://github.com/suxrobGM/MagicMvvm/tree/main/samples)


## License and copyright
Copyright Sukhrob Ilyosbekov 2021. Distributed under the [MIT License](https://github.com/suxrobGM/MagicMvvm/blob/main/LICENSE).


[CoreNuGet]: https://www.nuget.org/packages/MagicMvvm.Core/
[WpfNuGet]: https://www.nuget.org/packages/MagicMvvm.Wpf/
[CoreNuGetShield]: https://img.shields.io/nuget/vpre/MagicMvvm.Core.svg
[WpfNuGetShield]: https://img.shields.io/nuget/vpre/MagicMvvm.Wpf.svg