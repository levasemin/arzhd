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
    public partial class Pharmacy : ContentPage
    {
        public bool itemclass;
        class Pharma
        {
            public Pharma(string name, string time = null, string desc = null, string price = null)
            {
                this.Name = name;
                this.Desc = desc;
                this.Time = time;
                this.Price = price;
            }

            public string Name { private set; get; }
            public string Desc { private set; get; }
            public string Time { private set; get; }
            public string Price { private set; get; }
        };
        public Pharmacy(bool item)
        {
            InitializeComponent();
            itemclass = item;
            pharmslist.SeparatorColor = Color.FromHex("#F44336");
            if (item == false)
            {
                pharmslist.SeparatorColor = Color.FromHex("#FFFFFF");
                BackgroundColor = Color.FromHex("#424242");
            }
            Title = "Аптеки";
            List<Pharma> foods = new List<Pharma>();
            pharmslist.ItemTapped += Serviceslist_ItemTapped;
            pharmslist.ItemsSource = foods;
            pharmslist.SelectionMode = 0;
            pharmslist.HasUnevenRows = true;
            pharmslist.Margin = 10;
            pharmslist.ItemTemplate = new DataTemplate(() =>
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
            Pharma service = (Pharma)e.Item;
            await Navigation.PushAsync(new Info(itemclass, service.Name, service.Time, service.Price, service.Desc));
        }
    
    }
}