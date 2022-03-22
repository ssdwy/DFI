using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_UE4_Gruppe11
{
    public class Sensor
    {
        private int sen_ID;
        private int sen_Pfl_ID;
        private string sen_Bezeichnung;

        public int Sen_ID { get => sen_ID; set => sen_ID = value; }
        public int Sen_Pfl_ID { get => sen_Pfl_ID; set => sen_Pfl_ID = value; }
        public string Sen_Bezeichnung { get => sen_Bezeichnung; set => sen_Bezeichnung = value; }
    }
}
