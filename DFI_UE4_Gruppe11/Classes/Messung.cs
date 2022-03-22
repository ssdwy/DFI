using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFI_UE4_Gruppe11
{
    public class Messung
    {
        private int mes_ID;
        private int mes_Sen_ID;
        private string mes_DatumUhrzeit;
        private double mes_Temperatur;
        private double mes_Feuchtigkeit;

        public int Mes_ID { get => mes_ID; set => mes_ID = value; }
        public int Mes_Sen_ID { get => mes_Sen_ID; set => mes_Sen_ID = value; }
        public string Mes_DatumUhrzeit { get => mes_DatumUhrzeit; set => mes_DatumUhrzeit = value; }
        public double Mes_Temperatur { get => mes_Temperatur; set => mes_Temperatur = value; }
        public double Mes_Feuchtigkeit { get => mes_Feuchtigkeit; set => mes_Feuchtigkeit = value; }
    }
}
