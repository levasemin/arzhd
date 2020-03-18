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
        public Info(string name, string time, string desc, bool item)
        {
            InitializeComponent();
            if (item == false)
            {
                worktimetitle.TextColor = Color.FromHex("#FFFFFF");
                worktime.TextColor = Color.FromHex("#FFFFFF");
                descr.TextColor = Color.FromHex("#FFFFFF");
                description.TextColor = Color.FromHex("#FFFFFF");
                BackgroundColor = Color.FromHex("#424242");
            }
            else 
            {
                worktimetitle.TextColor = Color.FromHex("#000000");
                worktime.TextColor = Color.FromHex("#000000");
                descr.TextColor = Color.FromHex("#000000");
                description.TextColor = Color.FromHex("#000000");
                BackgroundColor = Color.FromHex("#FFFFFF");
            }
            Title = name;
            worktimetitle.Text = "Время работы:";
            worktime.Text = time;
            descr.Text = "Описание:";
            description.Text = desc;
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
        }
    }
}