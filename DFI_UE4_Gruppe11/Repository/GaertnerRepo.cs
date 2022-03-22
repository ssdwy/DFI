using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;

namespace DFI_UE4_Gruppe11
{
    class GaertnerRepo
    {
        public static List<Gaertner> ReadAll() // Anfrage nach alle Pflanze
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<Gaertner>("SELECT * FROM Gaertner").ToList();
            }
        }

        public static List<Gaertner> ReadAllgaertners(Gaertner gaertner) // Anfrage nach Pflanze entsprecend der Gaertner
        {
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                return db.Query<Gaertner>("SELECT * FROM betreut WHERE Bet_Gae_ID=" + gaertner.Gae_ID).ToList();
            }
        }
        public static void UpdateGaertner(Gaertner gaertner) // Updata Gaertner
        {
            string sql = "UPDATE Gaertner SET Gae_Nachname = @Gae_Nachname, Gae_Vorname = @Gae_Vorname, Gae_Aktiv = @Gae_Aktiv WHERE Gae_ID = @Gae_ID";
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                db.Execute(sql, new { Gae_ID = gaertner.Gae_ID, Gae_Nachname = gaertner.Gae_Nachname, Gae_Vorname = gaertner.Gae_Vorname, Gae_Aktiv = gaertner.Gae_Aktiv });
            }
        }
        public static void InsertGaetner(Gaertner gaertner) // Neu erstellen
        {
            string sql = "INSERT INTO Gaertner(Gae_Nachname, Gae_Vorname, Gae_Aktiv) VALUES (@Gae_Nachname, @Gae_Vorname, @Gae_Aktiv)";
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                db.Execute(sql, new { Gae_ID = gaertner.Gae_ID, Gae_Nachname = gaertner.Gae_Nachname, Gae_Vorname = gaertner.Gae_Vorname, Gae_Aktiv = gaertner.Gae_Aktiv });
            }
        }
        public static void DeleteGaertner(Gaertner gaertner) // Loeschen
        {
            string sql = "DELETE FROM Gaertner WHERE Gae_ID = @Gae_ID";
            using (SQLiteConnection db = SQLiteBaseRepo.SimpleDbConnection())
            {
                db.Execute(sql, new { Gae_ID = gaertner.Gae_ID });
            }
        }
    }
}