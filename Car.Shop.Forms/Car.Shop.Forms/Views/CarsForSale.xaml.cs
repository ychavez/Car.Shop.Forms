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

        private void OnFavorite_Clicked(object sender, EventArgs e) => DisplayAlert("AutoFavorito",
            (new DataBaseManager().AddFavoriteCar(
                (Models.Car)((Button)sender).BindingContext)) ? "Auto agregado con exito" : "El auto ya se encuentra en favoritos", "Ok");

        void OnSearchCar(object sender, EventArgs e)
        {
            string searchTex = searchBar.Text.ToUpper();
            var carsSearched =
                new RestService().GetCars().Where(x => x.Model.ToUpper().Contains(searchTex) ||
                x.Description.ToUpper().Contains(searchTex) || x.Brand.ToUpper().Contains(searchTex)).ToList();
            carList.ItemsSource = carsSearched;
        }
    }
}