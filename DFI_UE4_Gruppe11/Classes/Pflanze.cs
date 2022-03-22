using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_UE4_Gruppe11
{
    public class Pflanze
    {
        private int pfl_ID;
        private int pfl_Hab_ID;
        private int pfl_Gew_ID;
        private string pfl_Bezeichnung;
        private double pfl_Wasserverbrauch;
        private double pfl_Duengerverbrauch;

        public int Pfl_ID { get => pfl_ID; set => pfl_ID = value; }
        public int Pfl_Hab_ID { get => pfl_Hab_ID; set => pfl_Hab_ID = value; }
        public int Pfl_Gew_ID { get => pfl_Gew_ID; set => pfl_Gew_ID = value; }
        public string Pfl_Bezeichnung { get => pfl_Bezeichnung; set => pfl_Bezeichnung = value; }
        public double Pfl_Wasserverbrauch { get => pfl_Wasserverbrauch; set => pfl_Wasserverbrauch = value; }
        public double Pfl_Duengerverbrauch { get => pfl_Duengerverbrauch; set => pfl_Duengerverbrauch = value; }

    }
}
