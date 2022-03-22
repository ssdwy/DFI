using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;

namespace DFI_UE4_Gruppe11
{
    class MessungRepo
    {
        public static List<Messung> GetMessungData(int sensorID) // Anfrage nach Messung entsprechend der SensorID
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<Messung>("SELECT * FROM Messung WHERE Mes_Sen_ID = " + sensorID + " ORDER BY Mes_DatumUhrzeit").ToList();
            }
        }
    }
}
