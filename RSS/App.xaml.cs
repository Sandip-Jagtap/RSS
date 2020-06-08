using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            string androidAppSecret = "7ea84170-8351-43e1-82cb-6339e4657c6f";
            string iOSAppSecret = "3b21ac14-4d69-401b-81a3-41eb3c3e72f1";
            AppCenter.Start($"android={androidAppSecret};ios={iOSAppSecret}",typeof(Crashes), typeof(Analytics));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
