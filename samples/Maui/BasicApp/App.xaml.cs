﻿using BasicApp.Views;

namespace BasicApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = MauiProgram.GetService<MainPage>();
    }
}