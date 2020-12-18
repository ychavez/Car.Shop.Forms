using Car.Shop.Forms.Context;
using Plugin.Geolocator;
using Plugin.Media.Abstractions;
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
    public partial class AddCar : ContentPage
    {
        public AddCar()
        {
            InitializeComponent();
        }
        private async void bAdd_Click(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            var position = await locator.GetPositionAsync();
            new RestService().SetCars(new Models.Car
            {
                Brand = eBrand.Text,
                Description = eDescription.Text,
                Model = eModel.Text,
                Price = decimal.Parse(ePrice.Text),
                Year = int.Parse(eYear.Text),
                PhotoUrl = "https://i.blogs.es/727241/ncv-06/450_1000.jpg",
                Lat = position.Latitude,
                Lon = position.Longitude
            });
            await DisplayAlert("Agregado", "El auto se ha agregago", "Aceptar");
            MessagingCenter.Send<Page>(this, "Update");
            await Navigation.PopAsync();
        }

        private async void bTakePhoto_Click(object sender, EventArgs e) {
            if (Plugin.Media.CrossMedia.Current.IsTakePhotoSupported && Plugin.Media.CrossMedia.Current.IsCameraAvailable)
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { SaveToAlbum = false, SaveMetaData = false});

                if (photo != null)
                {
                    ImgMain.Source = ImageSource.FromStream(() => { return photo.GetStream();});
                }
            
            }
        }

        private async void bMap_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new MyMap());
    }
}