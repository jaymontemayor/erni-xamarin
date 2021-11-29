using System;
using UserApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new UserPage());
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
