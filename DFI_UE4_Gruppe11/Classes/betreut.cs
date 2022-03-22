using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_UE4_Gruppe11
{
    public class betreut
    {
        private int bet_ID;
        private int bet_Gew_ID;
        private int bet_Gae_ID;
        private string bet_Datum;

        public int Bet_ID { get => bet_ID; set => bet_ID = value; }
        public int Bet_Gew_ID { get => bet_Gew_ID; set => bet_Gew_ID = value; }
        public int Bet_Gae_ID { get => bet_Gae_ID; set => bet_Gae_ID = value; }
        public string Bet_Datum { get => bet_Datum; set => bet_Datum = value; }
    }
}
