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
    public partial class FavoriteCars : ContentPage
    {
        public FavoriteCars()
        {
            InitializeComponent();
            Title = "Favoritos";
            LoadList();
        }

        void LoadList() => carList.ItemsSource = new DataBaseManager().GetFavoriteCars();
    }
}