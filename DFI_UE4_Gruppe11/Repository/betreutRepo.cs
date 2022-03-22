using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;

namespace DFI_UE4_Gruppe11
{
    class betreutRepo
    {
        public static List<betreut> ReadAllbetreut(Gaertner gaertner) // Anfrage nach betreut num. entsprecend der Gaertner
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<betreut>("SELECT * FROM betreut WHERE Bet_Gae_ID=" + gaertner.Gae_ID ).ToList();
            }
        }
    }
}
