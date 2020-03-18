using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ARZHD.Services;
using ARZHD.Views;
using Xamarin.Essentials;

namespace ARZHD

{
    public partial class App : Application
    {
        
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new StartPage())
            {
                BarBackgroundColor = Color.FromHex("#F44336")
            };
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
