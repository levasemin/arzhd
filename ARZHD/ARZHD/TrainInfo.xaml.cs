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
   
    public partial class TrainInfo : ContentPage
    {

        public TrainInfo(string name, List<string> time, string day, Dictionary<string, string> types, bool item)
        {
            InitializeComponent();
            Title = name;
            var layout = new StackLayout();
            Label titletimefrom = new Label();
            Label titletimeto = new Label();
            Label timefrom = new Label();
            Label timeto = new Label();
            if (item)
            {
                titletimefrom = new Label() { Text = "Московское время отправления", Margin = new Thickness(25, 5, 0, 0), Style = Device.Styles.TitleStyle };
                titletimeto = new Label() { Text = "Московское время прибытия", Margin = new Thickness(25, 5, 0, 0), Style = Device.Styles.TitleStyle };
                timefrom = new Label() { Margin = new Thickness(30, 0, 0, 0), Style = Device.Styles.TitleStyle, FontSize = 17 };
                timeto = new Label() { Margin = new Thickness(30, 0, 0, 10), Style = Device.Styles.TitleStyle, FontSize = 17 };
            }
            else 
            {
                titletimefrom = new Label() { Text = "Москвоское время отправления", Margin = new Thickness(25, 5, 0, 0), Style = Device.Styles.TitleStyle, TextColor = Color.FromHex("#FFFFFF") };
                titletimeto = new Label() { Text = "Московское время прибытия", Margin = new Thickness(25, 5, 0, 0), Style = Device.Styles.TitleStyle, TextColor = Color.FromHex("#FFFFFF") };
                timefrom = new Label() { Margin = new Thickness(30, 0, 0, 0), Style = Device.Styles.TitleStyle, FontSize = 17, TextColor = Color.FromHex("#FFFFFF") };
                timeto = new Label() { Margin = new Thickness(30, 0, 0, 10), Style = Device.Styles.TitleStyle, FontSize = 17, TextColor = Color.FromHex("#FFFFFF") };
                BackgroundColor = Color.FromHex("#424242");
            }
            ViewCell list = new ViewCell();
            if (time.Count == 2)
            {
                timefrom.Text = day + " " + time[0];
                timeto.Text = day + " " + time[1];
            }
            if (time.Count == 3)
            {
                timefrom.Text = day + " " + time[0];
                string date = ""; 
                string numbers = "1234567890";
                bool prov = false;
                foreach (char st in time[1])
                {
                    if (numbers.IndexOf(st) > -1)
                    { date += st; prov = true;} ;
                    if (st == '.' && prov == true)
                        date += '/';
                }
                date += "/2020";
                timeto.Text = date + " " + time[2];
            }
            layout.Children.Add(titletimefrom);
            layout.Children.Add(timefrom);
            layout.Children.Add(titletimeto);
            layout.Children.Add(timeto);
            types.Remove("");
            foreach (string key in types.Keys) 
            {
                int n = key.IndexOf('(');
                int n1 = key.IndexOf(')');
                Label freeseatstitle = new Label();
                Label freeseats = new Label();
                if (item)
                {
                    if (key.Substring(0, n - 1).IndexOf("Плац") > -1)
                    freeseatstitle = new Label() { Text = "Свободные места в " + "Плацкарте" + ':', Margin = new Thickness(25, 0, 0, 0), Style = Device.Styles.TitleStyle, FontSize = 20 };
                    else
                        freeseatstitle = new Label() { Text = "Свободные места в " + key.Substring(0, n - 1) + ':', Margin = new Thickness(25, 0, 0, 0), Style = Device.Styles.TitleStyle, FontSize = 20 };
                    freeseats = new Label() { Text = key.Substring(n + 1, n1 - n - 1) + " мест " + types[key] + '₽', Margin = new Thickness(30, 0, 0, 0), Style = Device.Styles.TitleStyle, FontSize = 17 };
                }
                else 
                {
                    if (key.Substring(0, n - 1).IndexOf("Плац") > -1)
                        freeseatstitle = new Label() { Text = "Свободные места в " + "Плацкарте" + ':', Margin = new Thickness(25, 0, 0, 0), Style = Device.Styles.TitleStyle, FontSize = 20, TextColor = Color.FromHex("#FFFFFF") };
                    else
                        freeseatstitle = new Label() { Text = "Свободные места в " + key.Substring(0, n - 1) + ':', Margin = new Thickness(25, 0, 0, 0), Style = Device.Styles.TitleStyle, FontSize = 20, TextColor = Color.FromHex("#FFFFFF") };
                    freeseats = new Label() { Text = key.Substring(n + 1, n1 - n - 1) + " мест " + types[key] + '₽', Margin = new Thickness(30, 0, 0, 0), Style = Device.Styles.TitleStyle, FontSize = 17, TextColor = Color.FromHex("#FFFFFF") };
                }
                layout.Children.Add(freeseatstitle);
                layout.Children.Add(freeseats);
            }
            ScrollView scrollView = new ScrollView();
            layout.Spacing = 10;
            scrollView.Content = layout;
            this.Content = scrollView;
        }
    }
   
}