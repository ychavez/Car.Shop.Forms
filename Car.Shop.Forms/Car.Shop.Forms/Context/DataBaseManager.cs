using Car.Shop.Forms.DependencyServices;
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
            if (!TableExists("Car"))
                db.CreateTable<Models.Car>();
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

        public List<Models.Car> GetFavoriteCars() => db.Query<Models.Car>("select * from car");

        public bool AddFavoriteCar(Models.Car car)
        {
            if (db.Query<Models.Car>($"select * from car where id = {car.Id}").Count > 0)
                return false;

            db.Insert(car);
            return true;
        }

    }
}
