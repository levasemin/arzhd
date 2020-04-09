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
    public partial class Info : ContentPage
    {
        public Info(bool item, string name=null, string time=null, string price=null, string desc=null)
        {
            InitializeComponent();
            var layout = new StackLayout();
            Title = name;
            if (item == false)
            {
                BackgroundColor = Color.FromHex("#424242");
                if (time != null)
                {
                    layout.Children.Add(new Label() { Text = "Время работы:", TextColor = Color.FromHex("#FFFFFF"), Style = Device.Styles.TitleStyle });
                    layout.Children.Add(new Label() { Text = time, TextColor = Color.FromHex("#FFFFFF"), Style = Device.Styles.TitleStyle, FontSize = 19 });
                }
                if (price != null)
                {
                    layout.Children.Add(new Label() { Text = "Цена:", TextColor = Color.FromHex("#FFFFFF"), Style = Device.Styles.TitleStyle });
                    layout.Children.Add(new Label() { Text = price, TextColor = Color.FromHex("#FFFFFF"), Style = Device.Styles.TitleStyle, FontSize = 19 });
                }
                if (desc != null)
                {
                    layout.Children.Add(new Label() { Text = "Описание:", TextColor = Color.FromHex("#FFFFFF"), Style = Device.Styles.TitleStyle });
                    layout.Children.Add(new Label() { Text = desc, TextColor = Color.FromHex("#FFFFFF"), Style = Device.Styles.TitleStyle, FontSize = 19 });
                }
            }
            else 
            {
                BackgroundColor = Color.FromHex("#FFFFFF");
                if (time != null)
                {
                    layout.Children.Add(new Label() { Text = "Время работы:", TextColor = Color.FromHex("Black"), Style = Device.Styles.TitleStyle });
                    layout.Children.Add(new Label() { Text = time, TextColor = Color.FromHex("Black"), Style = Device.Styles.TitleStyle, FontSize = 19 });
                }
                if (price != null)
                {
                    layout.Children.Add(new Label() { Text = "Цена:", TextColor = Color.FromHex("Black"), Style= Device.Styles.TitleStyle});
                    layout.Children.Add(new Label() { Text = price, TextColor = Color.FromHex("Black"), Style = Device.Styles.TitleStyle, FontSize = 19 });
                }
                if (desc != null)
                {
                    layout.Children.Add(new Label() { Text = "Описание:", TextColor = Color.FromHex("Black"), Style = Device.Styles.TitleStyle });
                    layout.Children.Add(new Label() { Text = desc, TextColor = Color.FromHex("Black"), Style = Device.Styles.TitleStyle, FontSize = 19 });
                }
            }
            
            ToolbarItem tb = new ToolbarItem()
            {
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Icon = new FileImageSource() 
                {
                    File = "way2.png"
                }
            };
            ToolbarItems.Add(tb);
            ScrollView scrollView = new ScrollView();
            layout.Margin = 16;
            scrollView.Content = layout;
            Content = scrollView;
        }
    }
}