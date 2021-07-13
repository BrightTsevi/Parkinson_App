using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkinson_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /*MainPage = new MainPage();*/
            MainPage = new NavigationPage(new Parkinson_App.MainPage());
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
