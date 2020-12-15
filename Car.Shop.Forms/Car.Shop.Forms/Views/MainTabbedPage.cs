using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Car.Shop.Forms.Views
{
    public class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            Title = "Sell my car";
            Children.Add(new CarsForSale());
            Children.Add(new NearCars());
           
           
        }
    }
}
