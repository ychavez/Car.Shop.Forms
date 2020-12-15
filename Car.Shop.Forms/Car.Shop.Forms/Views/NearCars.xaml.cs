using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Car.Shop.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NearCars : ContentPage
    {
        public NearCars()
        {
            InitializeComponent();
            Title = "Autos cerca";
        }
    }
}