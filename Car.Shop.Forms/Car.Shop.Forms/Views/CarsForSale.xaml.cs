using Car.Shop.Forms.Context;
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
    public partial class CarsForSale : ContentPage
    {
        public CarsForSale()
        {
            InitializeComponent();
            LoadList();
            Title = "Comprar";
        }

        void onAdd(object sender, EventArgs e) => Navigation.PushAsync(new AddCar());

        void LoadList() => carList.ItemsSource = new RestService().GetCars();
        
    }
}