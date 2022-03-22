using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_UE4_Gruppe11
{
    public class Gaertner
    {
        private int gae_ID;
        private string gae_Nachname;
        private string gae_Vorname;
        private bool gae_Aktiv;

        public int Gae_ID { get => gae_ID; set => gae_ID = value; }
        public string Gae_Nachname { get => gae_Nachname; set => gae_Nachname = value; }
        public string Gae_Vorname { get => gae_Vorname; set => gae_Vorname = value; }
        public bool Gae_Aktiv { get => gae_Aktiv; set => gae_Aktiv = value; }
    }
}
