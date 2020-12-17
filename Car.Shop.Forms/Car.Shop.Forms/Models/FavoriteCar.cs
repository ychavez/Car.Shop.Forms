using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Shop.Forms.Models
{
    public class FavoriteCar : Car
    {
        [PrimaryKey, AutoIncrement]
        public int FavoriteCarId { get; set; }

    }
}
