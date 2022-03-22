using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;

namespace DFI_UE4_Gruppe11
{
    class SQLiteBaseRepo
    {
        public static string Dbfile = "";
        public static SQLiteConnection SimpleDbConnection()
        {   
            return new SQLiteConnection("Data Source=" + Dbfile);
        }
    }
      
}
