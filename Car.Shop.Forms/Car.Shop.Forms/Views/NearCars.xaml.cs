using Car.Shop.Forms.Context;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
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
            SetmapCars();
        }

        private async void SetmapCars()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 10;
            var position = await locator.GetPositionAsync();

            Circle circle = new Circle
            {
                Center = MapManager.GetXamPosition(position),
                Radius = new Distance(2500),
                StrokeColor = Color.Blue,
                StrokeWidth = 8,
                FillColor = Color.LightCyan
            };

            List<Pin> pins = new List<Pin>();
            new RestService().GetCars().ForEach(x =>
            {
                if (!(x.Lon == null || x.Lat == null))
                    pins.Add(new Pin
                    {
                        Type = PinType.SearchResult,
                        Label = string.Concat(x.Brand, x.Model),
                        Position = new Position(x.Lat.Value, x.Lon.Value),
                        Address = x.Description
                    });
            });

            Content = new MapManager().GetMap(true, new Position(position.Latitude, position.Longitude), pins: pins, circle:circle);


        }
    }
}