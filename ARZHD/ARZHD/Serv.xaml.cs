using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ARZHD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Serv : ContentPage
    {
        public bool item;
        public Serv(Color color)
        {
            InitializeComponent();
            BackgroundColor = color;
            station.Clicked += Station_Clicked;
            food.Clicked += Food_Clicked;
            Title = "Сервисы";
            if (color == Color.FromHex("#FFFFFF"))
            {
                item = true;
            }
            else
            {
                item = false;
                pharmacy.BackgroundColor = Color.FromHex("#424242");
                pharmacy.BorderColor = Color.FromHex("#000000");
                food.BackgroundColor = Color.FromHex("#424242");
                food.BorderColor = Color.FromHex("#000000");
                shop.BackgroundColor = Color.FromHex("#424242");
                shop.BorderColor = Color.FromHex("#000000");
                station.BackgroundColor = Color.FromHex("#424242");
                station.BorderColor = Color.FromHex("#000000");
            }
        }

        private async void Food_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Food(item));
        }

        private async void Station_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Stationserv(item));
        }
    }
}