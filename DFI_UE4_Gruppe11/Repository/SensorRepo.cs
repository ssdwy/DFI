using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;

namespace DFI_UE4_Gruppe11
{
    class SensorRepo
    {
        public static List<int> GetSensorData(Pflanze pflanze) // Anfrage nach Sensor entsprechend der Pflanze
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<int>("SELECT Sen_ID FROM Sensor WHERE Sen_Pfl_ID= " + pflanze.Pfl_ID).ToList();
            }
        }
    }
}
