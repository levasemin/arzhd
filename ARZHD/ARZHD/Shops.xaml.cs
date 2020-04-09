using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ARZHD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shops : ContentPage
    {
        public bool itemclass;
        class Shop
        {
            public Shop(string name, string time, string desc)
            {
                this.Name = name;
                this.Desc = desc;
                this.Time = time;
            }

            public string Name { private set; get; }
            public string Desc { private set; get; }
            public string Time { private set; get; }
        };
        public Shops(bool item)
        {
            InitializeComponent();
            itemclass = item;
            shopslist.SeparatorColor = Color.FromHex("#F44336");
            if (item == false)
            {
                shopslist.SeparatorColor = Color.FromHex("#FFFFFF");
                BackgroundColor = Color.FromHex("#424242");
            }
            Title = "Магазины";
            List<Shop> foods = new List<Shop>();
            shopslist.ItemTapped += Serviceslist_ItemTapped;
            shopslist.ItemsSource = foods;
            shopslist.SelectionMode = 0;
            shopslist.HasUnevenRows = true;
            shopslist.Margin = 10;
            shopslist.ItemTemplate = new DataTemplate(() =>
            {
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                nameLabel.Style = Device.Styles.TitleStyle;
                nameLabel.FontSize = 20;
                nameLabel.Margin = 10;
                if (item == false)
                {
                    nameLabel.TextColor = Color.FromHex("#FFFFFF");
                }
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Children =
                        {
                            new StackLayout
                            {
                                Children =
                                {
                                    nameLabel
                                }
                            }
                        }
                    }
                };
            });
        }

        private async void Serviceslist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Shop service = (Shop)e.Item;
            await Navigation.PushAsync(new Info(service.Name, service.Time, service.Desc, itemclass));
        }
    }
}