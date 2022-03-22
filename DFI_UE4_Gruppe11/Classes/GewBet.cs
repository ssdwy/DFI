using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_UE4_Gruppe11
{
    class GewBet
    {
        private DateTime datum;
        private string gewaechshaus;
        private betreut betreut;
        public DateTime Datum { get => datum; set => datum = value; }
        public string Gewaechshaus { get => gewaechshaus; set => gewaechshaus = value; }
        public betreut Betreut { get => betreut; set => betreut = value; }

        public GewBet(betreut betreut, Gewaechshaus gewaechshaus)
        {
            this.betreut = betreut;
            datum = DateTime.ParseExact(betreut.Bet_Datum, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            this.gewaechshaus = gewaechshaus.Gew_Bezeichnung;
        }
    }
}
