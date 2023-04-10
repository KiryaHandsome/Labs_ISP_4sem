using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public static class Constants
    {
        public const string DatabaseFilePath = "E:\\labs_4sem\\Labs_ISP_4sem\\Project\\Project\\Database\\hotel.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create;

        public const string DropTableIfExistsQuery = "DROP TABLE IF EXISTS ";
    }
}
