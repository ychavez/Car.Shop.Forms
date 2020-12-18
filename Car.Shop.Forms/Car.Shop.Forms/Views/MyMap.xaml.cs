using Plugin.Geolocator;
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
    public partial class MyMap : ContentPage
    {
        public MyMap()
        {
            InitializeComponent();
            getLocation();
        }
        private async void getLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;
            var position = await locator.GetPositionAsync();
            Content = new MapManager().GetMap(true, MapManager.GetXamPosition(position));
        }
    }
}