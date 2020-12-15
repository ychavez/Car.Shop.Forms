using Car.Shop.Forms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Car.Shop.Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainTabbedPage());
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
