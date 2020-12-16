using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Shop.Forms.DependencyServices
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
