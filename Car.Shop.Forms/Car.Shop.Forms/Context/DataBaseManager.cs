using Car.Shop.Forms.DependencyServices;
using Car.Shop.Forms.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace Car.Shop.Forms.Context
{
    public class DataBaseManager
    {
        private SQLiteConnection db;
        public DataBaseManager()
        {
            db = DependencyService.Get<ISQLite>().GetConnection();
            Migrations();
        }

        private void Migrations()
        {
            if (TableExists("Car"))
                db.DropTable<Models.Car>();
            if (!TableExists("FavoriteCar"))
                db.CreateTable<FavoriteCar>();
        }

        private bool TableExists(string tableName)
        {
            TableMapping map = new TableMapping(typeof(SqlDbType));

            int tableCount =
                db.Query(map, $"select * from sqlite_master where type = 'table' and name = '{tableName}'").Count;

            if (tableCount > 1)
                throw new Exception($"Hay mas de una tabla con el nombre {tableName} en la base de datos");
            return (tableCount == 1);
        }

        public List<FavoriteCar> GetFavoriteCars() => db.Query<FavoriteCar>("select * from FavoriteCar");

        public bool AddFavoriteCar(Models.Car car)
        {
            if (db.Query<FavoriteCar>($"select * from FavoriteCar where id = {car.Id}").Count > 0)
                return false;

            db.Insert(new FavoriteCar
            {
                Brand = car.Brand,
                Description = car.Description,
                Model = car.Model,
                Year = car.Year,
                PhotoUrl = car.PhotoUrl,
                Price = car.Price,
                Lat = car.Lat,
                Lon = car.Lon,
                Id = car.Id
            });
            return true;
        }
        public void DeleteFavorite(int Id) => db.Delete<FavoriteCar>(Id);

    }
}
