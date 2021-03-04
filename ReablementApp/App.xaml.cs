using ReablementApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReablementApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            // MainPage = new AppShell();

            //TODO if current user is say manager then load certain app shell??...
            //MainPage = new LoginPage();

            MainPage = new ClientHomePage();
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
