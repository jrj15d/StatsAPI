using StatsMobile.Services;
using StatsMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StatsMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<PlayerStore>();
            MainPage = new AppShell();
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
