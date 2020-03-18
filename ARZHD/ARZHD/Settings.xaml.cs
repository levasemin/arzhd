using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace ARZHD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings(Color color)
        {
            InitializeComponent();
            if (color == Color.FromHex("#424242"))
            {
                lang.TextColor = Color.FromHex("#FFFFFF");
                picker.TextColor = Color.FromHex("#FFFFFF");
                city.TextColor = Color.FromHex("#FFFFFF");
                picker1.TextColor = Color.FromHex("#FFFFFF");
            }
            Title = "Настройки";
            settings.HasUnevenRows = true;
            BackgroundColor = color;
        }
    }
}