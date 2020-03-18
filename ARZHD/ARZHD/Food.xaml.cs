using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ARZHD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Food : ContentPage
    {
        public bool itemclass;
        class Cafe
        {
            public Cafe(string name, string time, string desc)
            {
                this.Name = name;
                this.Desc = desc;
                this.Time = time;
            }

            public string Name { private set; get; }
            public string Desc { private set; get; }
            public string Time { private set; get; }
        };
        public Food(bool item)
        {
            InitializeComponent();
            itemclass = item;
            cafeslist.SeparatorColor = Color.FromHex("#F44336");
            if (item == false)
            {
                cafeslist.SeparatorColor = Color.FromHex("#FFFFFF");
                BackgroundColor = Color.FromHex("#424242");
            }
            Title = "Еда";
            List<Cafe> cafes = new List<Cafe>();
            cafeslist.ItemTapped += Cafeslist_ItemTapped;
            cafes.Add(new Cafe("Экспресс", "c 5:00 до 1:00", "Высокая кухня и уникальная атмосфера отдыха. Приходите, не пожалеете! \n Первый этаж."));
            cafes.Add(new Cafe("Встреча", "c 8:00 до 1:00", "Цокольный этаж."));
            cafeslist.ItemsSource = cafes;
            cafeslist.SelectionMode = 0;
            cafeslist.HasUnevenRows = true;
            cafeslist.Margin = 10;
            cafeslist.ItemTemplate = new DataTemplate(() =>
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

        private async void Cafeslist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Cafe cafe = (Cafe)e.Item;
            await Navigation.PushAsync(new Info(cafe.Name, cafe.Time, cafe.Desc, itemclass));
        }
    }
}