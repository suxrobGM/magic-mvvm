[![BuildShield](https://github.com/suxrobGM/MagicMvvm/actions/workflows/dotnet.yml/badge.svg)](https://github.com/suxrobGM/MagicMvvm/actions/workflows/dotnet.yml)
[![BuildShield](https://github.com/suxrobGM/MagicMvvm/actions/workflows/publish.yml/badge.svg)](https://github.com/suxrobGM/MagicMvvm/actions/workflows/publish.yml)

# MagicMvvm
MagicMvvm is lightweight library for building rapid MVVM applications. Project inspired from [Prism](https://github.com/PrismLibrary/Prism) and used the best Prism practices, and made a lightweight library. The main difference from Prism is that supporting any IoC container (IoC container agnostic). You can use this library with any IoC container.
Currently WPF, Blazor and Xamarin.Forms platforms are supported.

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
* Platform specific features for WPF, Blazor, and Xamarin.Forms.

## NuGet packages

| Platform | Package | NuGet |
| -------- | ------- | ------- |
| Cross Platform | [MagicMvvm.Core][CoreNuGet] | [![CoreNuGetShield]][CoreNuGet] |
| WPF | [MagicMvvm.Wpf][WpfNuGet] | [![WpfNuGetShield]][WpfNuGet] |
| Blazor | [MagicMvvm.Blazor][BlazorNuGet] | [![BlazorNuGetShield]][BlazorNuGet]  |
| Xamarin.Forms | [MagicMvvm.Forms][FormsNuGet] | [![FormsNuGetShield]][FormsNuGet] |


## Documentation
Check out project documentation [here](https://github.com/suxrobGM/MagicMvvm/wiki)

## Samples
Explore sample applications [here](https://github.com/suxrobGM/MagicMvvm/tree/main/samples)


## License and copyright
Copyright Sukhrob Ilyosbekov 2021. Distributed under the [MIT License](https://github.com/suxrobGM/MagicMvvm/blob/main/LICENSE).


[CoreNuGet]: https://www.nuget.org/packages/MagicMvvm.Core/
[WpfNuGet]: https://www.nuget.org/packages/MagicMvvm.Wpf/
[BlazorNuGet]: https://www.nuget.org/packages/MagicMvvm.Blazor/
[FormsNuGet]: https://www.nuget.org/packages/MagicMvvm.Forms/
[CoreNuGetShield]: https://img.shields.io/nuget/vpre/MagicMvvm.Core.svg
[WpfNuGetShield]: https://img.shields.io/nuget/vpre/MagicMvvm.Wpf.svg
[BlazorNuGetShield]: https://img.shields.io/nuget/vpre/MagicMvvm.Blazor.svg
[FormsNuGetShield]: https://img.shields.io/nuget/vpre/MagicMvvm.Forms.svg
