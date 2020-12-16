
using Car.Shop.Forms.DependencyServices;
using Car.Shop.Forms.iOS;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteiOS))]
namespace Car.Shop.Forms.iOS
{
    public class SQLiteiOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqliteFilename = "Cars.db3";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libPath = Path.Combine(docPath, "..", "Library");
            string path = Path.Combine(libPath, sqliteFilename);
            SQLiteConnection conn = new SQLiteConnection(path);
            return conn;
        }
    }
}