using Car.Shop.Forms.Context;
using Car.Shop.Forms.Models;
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
    public partial class FavoriteCars : ContentPage
    {
        public FavoriteCars()
        {
            InitializeComponent();
            Title = "Favoritos";
            LoadList();
            MessagingCenter.Subscribe<Page>(this, "UpdateFavorite", MessageCallback);
        }

        private void MessageCallback(Page obj) => LoadList();

        void LoadList() => carList.ItemsSource = new DataBaseManager().GetFavoriteCars();

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
           bool accept = await DisplayAlert("Eliminar favorito", "Esta usted seguro que quiere eliminar este coche?", "Si", "No");

            if (!accept)
                return;
            

            new DataBaseManager().DeleteFavorite(((FavoriteCar)((Button)sender).BindingContext).FavoriteCarId);
            LoadList();

        }
    }
}