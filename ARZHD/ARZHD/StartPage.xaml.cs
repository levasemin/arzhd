using System;
using System.Diagnostics;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ARZHD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            Navig.Clicked += Navig_Clicked;
            Service.Clicked += Service_Clicked;
            Navig.BackgroundColor = Color.FromHex("#F44336");
            Service.BackgroundColor = Color.FromHex("#F44336");
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Service_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void Navig_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Ошибка", "Вы находитесь не на Ижевском вокзале.", "Ok");
        }
    }
}