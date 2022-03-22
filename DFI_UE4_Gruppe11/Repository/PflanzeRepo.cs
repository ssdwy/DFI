using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;


namespace DFI_UE4_Gruppe11
{
    class PflanzeRepo
    {
        public static List<Pflanze> ReadAll() // Anfrage alle Pflanze
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<Pflanze>("SELECT * FROM Pflanze").ToList();
            }
        }
        public static List<Pflanze> ReadAllPflanzeData(Gewaechshaus gewaechshaus) // Anfrage der Pflanze durch Gewaechshaus
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<Pflanze>("SELECT * FROM Pflanze WHERE Pfl_Gew_ID=" + gewaechshaus.Gew_ID).ToList();
            }
        }
        public static List<int> CountPflanzeAnzahle(Gewaechshaus gewaechshaus) // Anfrage der Anzahl der Pflanze durch Gewaechshaus
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<int>("SELECT COUNT(Pfl_ID) FROM Pflanze WHERE Pfl_Gew_ID=" + gewaechshaus.Gew_ID).ToList();  
            }
        }
        public static List<int> SumPflanzeWasserverbrauch(Gewaechshaus gewaechshaus, int days) // Anfrage der Sum des Wasserverbrauchs
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {

                return db.Query<int>("SELECT SUM(Pfl_Wasserverbrauch) * " + days + " FROM Pflanze WHERE Pfl_Gew_ID=" + gewaechshaus.Gew_ID).ToList();

            }
        }
        public static List<int> SumPflanzeDuengerverbrauch(Gewaechshaus gewaechshaus, int days) // Anfrage der Sum des Duengerverbrauchs
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<int>("SELECT SUM(Pfl_Duengerverbrauch) * " + days + " / 30" + " FROM Pflanze WHERE Pfl_Gew_ID=" + gewaechshaus.Gew_ID).ToList();
            }
        }
        public static void UpdatePflanze(Pflanze pflanze) // Updata
        {
            string sql = "UPDATE Pflanze SET Pfl_Hab_ID = @Pfl_Hab_ID, Pfl_Gew_ID = @Pfl_Gew_ID, Pfl_Bezeichnung = @Pfl_Bezeichnung, Pfl_Wasserverbrauch = @Pfl_Wasserverbrauch, Pfl_Duengerverbrauch = @Pfl_Duengerverbrauch WHERE Pfl_ID = @Pfl_ID";
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                db.Execute(sql, new { Pfl_Hab_ID = pflanze.Pfl_Hab_ID, Pfl_Gew_ID = pflanze.Pfl_Gew_ID, Pfl_Bezeichnung = pflanze.Pfl_Bezeichnung, Pfl_Wasserverbrauch = pflanze.Pfl_Wasserverbrauch, Pfl_Duengerverbrauch = pflanze.Pfl_Duengerverbrauch, Pfl_ID = pflanze.Pfl_ID });
            }
        }
        public static void InsertPflanze(Pflanze pflanze) // Neu erstellen
        {
            string sql = "INSERT INTO Pflanze(Pfl_Hab_ID, Pfl_Gew_ID, Pfl_Bezeichnung, Pfl_Wasserverbrauch, Pfl_Duengerverbrauch) VALUES (@Pfl_Hab_ID, @Pfl_Gew_ID, @Pfl_Bezeichnung, @Pfl_Wasserverbrauch, @Pfl_Duengerverbrauch)";
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                db.Execute(sql, new { Pfl_Hab_ID = pflanze.Pfl_Hab_ID, Pfl_Gew_ID = pflanze.Pfl_Gew_ID, Pfl_Bezeichnung = pflanze.Pfl_Bezeichnung, Pfl_Wasserverbrauch = pflanze.Pfl_Wasserverbrauch, Pfl_Duengerverbrauch = pflanze.Pfl_Duengerverbrauch, Pfl_ID = pflanze.Pfl_ID });
            }
        }
        public static void DeletePflanze(Pflanze pflanze) // Loeschen
        {
            string sql = "DELETE FROM Pflanze WHERE Pfl_ID = @Pfl_ID";
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                db.Execute(sql, new { Pfl_ID = pflanze.Pfl_ID });
            }
        }
    }
}
