using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Car.Shop.Forms.DependencyServices;
using Car.Shop.Forms.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace Car.Shop.Forms.Droid
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqlFileName = "Cars.db3";
            string docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(docPath, sqlFileName);
            SQLiteConnection conn = new SQLiteConnection(path);
            return conn;
        }

    }
}