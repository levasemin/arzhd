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
    public partial class Tickets : ContentPage
    {
        public Tickets()
        {
            InitializeComponent();
            Title = "Билеты";
        }
    }
}