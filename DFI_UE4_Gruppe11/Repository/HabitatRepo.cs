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
    class HabitatRepo
    {
        public static List<Habitat> ReadAll() // Finden alle Habitat
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<Habitat>("SELECT * FROM Habitat").ToList();
            }
        }
        public static List<Habitat> Readhabitats(Pflanze pflanze) // Anfrage nach Habitat enspchend der Pflanze
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<Habitat>("SELECT * FROM Habitat WHERE Hab_ID = "+ pflanze.Pfl_Hab_ID).ToList();
            }
        }
        public static List<int> MaxTem(Pflanze pflanze) // Finden Max Tem.
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<int>("SELECT Hab_TemperaturMax FROM Habitat WHERE Hab_ID = " + pflanze.Pfl_Hab_ID).ToList();
            }
        }
        public static List<int> MinTem(Pflanze pflanze) // Finden min Tem.
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<int>("SELECT Hab_TemperaturMin FROM Habitat WHERE Hab_ID = " + pflanze.Pfl_Hab_ID).ToList();
            }
        }
        public static List<int> MaxFeu(Pflanze pflanze) // Finden Max Feu.
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<int>("SELECT Hab_FeuchtigkeitMax FROM Habitat WHERE Hab_ID = " + pflanze.Pfl_Hab_ID).ToList();
            }
        }
        public static List<int> MinFeu(Pflanze pflanze) // Finden min Feu.
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<int>("SELECT Hab_FeuchtigkeitMin FROM Habitat WHERE Hab_ID = " + pflanze.Pfl_Hab_ID).ToList();
            }
        }
    }
}
