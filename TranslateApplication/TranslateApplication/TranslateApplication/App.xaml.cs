﻿using System;
using TranslateApplication.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace TranslateApplication
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SearchPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
