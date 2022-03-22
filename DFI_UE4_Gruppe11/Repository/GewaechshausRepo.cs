using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;

namespace DFI_UE4_Gruppe11
{
    class GewaechshausRepo
    {
        public static List<Gewaechshaus> ReadAll() // Anfrage nach alle Gewaechshaus
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<Gewaechshaus>("SELECT * FROM Gewaechshaus").ToList();
            }
        }
        public static List<Gewaechshaus> Readgae(betreut betreut) // Anfrage nach Gewaechshaus ensprechend betreut num.
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<Gewaechshaus>("SELECT * FROM Gewaechshaus WHERE Gew_ID = " + betreut.Bet_Gew_ID).ToList();
            }
        }

    }
}
