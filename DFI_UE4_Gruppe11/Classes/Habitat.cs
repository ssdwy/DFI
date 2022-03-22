using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_UE4_Gruppe11
{
    public class Habitat
    {
        private int hab_ID;
        private string hab_Bezeichnung;
        private int hab_TemperaturMin;
        private int hab_TemperaturMax;
        private int hab_FeuchtigkeitMin;
        private int hab_FeuchtigkeitMax;

        public int Hab_ID { get => hab_ID; set => hab_ID = value; }
        public string Hab_Bezeichnung { get => hab_Bezeichnung; set => hab_Bezeichnung = value; }
        public int Hab_TemperaturMin { get => hab_TemperaturMin; set => hab_TemperaturMin = value; }
        public int Hab_TemperaturMax { get => hab_TemperaturMax; set => hab_TemperaturMax = value; }
        public int Hab_FeuchtigkeitMin { get => hab_FeuchtigkeitMin; set => hab_FeuchtigkeitMin = value; }
        public int Hab_FeuchtigkeitMax { get => hab_FeuchtigkeitMax; set => hab_FeuchtigkeitMax = value; }
        public override string ToString()
        {
            return hab_Bezeichnung;
        }
    }
}
