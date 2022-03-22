using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_UE4_Gruppe11
{
    public class Gewaechshaus
    {
        private int gew_ID;
        private String gew_Bezeichnung;
        private String gew_Strasse;
        private String gew_Hausnummer;

        public int Gew_ID { get => gew_ID; set => gew_ID = value; }
        public string Gew_Bezeichnung { get => gew_Bezeichnung; set => gew_Bezeichnung = value; }
        public string Gew_Strasse { get => gew_Strasse; set => gew_Strasse = value; }
        public string Gew_Hausnummer { get => gew_Hausnummer; set => gew_Hausnummer = value; }

        public override string ToString()
        {
            return gew_Bezeichnung;
        }
    }
}
