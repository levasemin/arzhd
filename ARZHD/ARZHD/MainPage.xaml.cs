using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace ARZHD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public bool item = true;
        public MainPage()
        {
            InitializeComponent();
            Children.Add(new TimeTable(Color.FromHex("#FFFFFF")) { IconImageSource = "timetable.png"});
            Children.Add(new Serv(Color.FromHex("#FFFFFF")) { IconImageSource = "station.png"});
            Children.Add(new Settings(Color.FromHex("#FFFFFF")) {IconImageSource = "settings.img"});
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            NavigationPage.SetHasBackButton(this, false);
            ((NavigationPage)Xamarin.Forms.Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#F44336");
            ToolbarItem tb = new ToolbarItem
            {
                Order = ToolbarItemOrder.Primary,
                IconImageSource = "moon.png",
            };
            tb.Clicked += Tb_Clicked;
            ToolbarItems.Add(tb);
        }

        private void Tb_Clicked(object sender, EventArgs e)
        {
            if (item)
            {
                Children.Remove(Children[0]);
                Children.Remove(Children[0]);
                Children.Remove(Children[0]);
                Children.Add(new TimeTable(Color.FromHex("#424242")) { IconImageSource = "timetable.png" });
                Children.Add(new Serv(Color.FromHex("#424242")) { IconImageSource = "station.png" });
                Children.Add(new Settings(Color.FromHex("#424242")) { IconImageSource = "settings.img" });
                item = false;
                SelectedTabColor = Color.FromHex("#FFFFFF");
                BarBackgroundColor = Color.FromHex("#424242");
                ((NavigationPage)Xamarin.Forms.Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#424242");
                ToolbarItems.Remove(ToolbarItems[0]);
                ToolbarItem tb = new ToolbarItem
                {
                    Order = ToolbarItemOrder.Primary,
                    IconImageSource = "moon2.png",
                };
                tb.Clicked += Tb_Clicked;
                ToolbarItems.Add(tb);
            }
            else
            {
                Children.Remove(Children[0]);
                Children.Remove(Children[0]);
                Children.Remove(Children[0]);
                Children.Add(new TimeTable(Color.FromHex("#FFFFFF")) { IconImageSource = "timetable.png" });
                Children.Add(new Serv(Color.FromHex("#FFFFFF")) { IconImageSource = "station.png" });
                Children.Add(new Settings(Color.FromHex("#FFFFFF")) { IconImageSource = "settings.img" });
                item = true;
                SelectedTabColor = Color.FromHex("#424242");
                BarBackgroundColor = Color.FromHex("#FFFFFF");
                ((NavigationPage)Xamarin.Forms.Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#F44336");
                ToolbarItems.Remove(ToolbarItems[0]);
                ToolbarItem tb = new ToolbarItem
                {
                    Order = ToolbarItemOrder.Primary,
                    IconImageSource = "moon.png",
                };
                tb.Clicked += Tb_Clicked;
                ToolbarItems.Add(tb);
            }
        }
    }
}