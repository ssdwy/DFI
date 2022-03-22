using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DFI_UE4_Gruppe11
{
    /// <summary>
    /// Messwerte.xaml 的交互逻辑
    /// </summary>
    public partial class Messwerte : Window
    {
        Pflanze pflanze;
        public Messwerte(Pflanze pflanze)
        {
            InitializeComponent();
            this.pflanze = pflanze;
            DiagrammErstelle();

        }
        public void DiagrammErstelle()
        {
            TemperaturDiagramm.Plot.XAxis.DateTimeFormat(true);
            int maxtem = HabitatRepo.MaxTem(pflanze)[0]; // Max.u. Min Tem.u. Feu
            int mintem = HabitatRepo.MinTem(pflanze)[0];
            int maxfeu = HabitatRepo.MaxFeu(pflanze)[0];
            int minfeu = HabitatRepo.MinFeu(pflanze)[0];

            List<int> SensorData = SensorRepo.GetSensorData(pflanze);
            List<DateTime> DatumList = new List<DateTime>();
            List<double> Fkeit = new List<double>();
            List<double> Tem = new List<double>();

            int i = 0;
            int ii = 0;

            foreach (Messung messung in MessungRepo.GetMessungData(SensorData[0]))
            {

                DatumList.Add(DateTime.Parse(messung.Mes_DatumUhrzeit));
                Fkeit.Add(messung.Mes_Feuchtigkeit);
                Tem.Add(messung.Mes_Temperatur);
               
                if (messung.Mes_Feuchtigkeit > minfeu && messung.Mes_Feuchtigkeit < maxfeu)
                {
                    i++;
                }
                if (messung.Mes_Temperatur > mintem && messung.Mes_Temperatur < maxtem)
                {
                    ii++;
                }
            }
            DateTime[] dataDatumUhrzeit = DatumList.ToArray();
            double[] dataFeuchtigkeit = Fkeit.ToArray();
            double[] dataTemperatur = Tem.ToArray();
            double Prozent = Math.Round((double)i / dataFeuchtigkeit.Length, 2); // Anzahl der zulässigen Feuchtigkeit
            string ProzentValue = (Prozent).ToString("0%");
            double ProzentTem = Math.Round((double)ii / dataTemperatur.Length, 2); // Anzahl der zulässigen Temperaturen
            string ProzentValueTem = (ProzentTem).ToString("0%"); 

            double[] dataDatum = dataDatumUhrzeit.Select(x => x.ToOADate()).ToArray();

            // Zeichnen
            TemperaturDiagramm.Plot.XAxis.DateTimeFormat(true); 
            TemperaturDiagramm.Plot.AddVerticalSpan(mintem, maxtem, System.Drawing.Color.LightYellow); // Condidation von Habitat
            TemperaturDiagramm.Plot.AddScatter(dataDatum, dataTemperatur);
            TemperaturDiagramm.Plot.Title("Temperaturverlauf Kalmien-Deutzie"); // Title
            TemperaturDiagramm.Plot.XLabel(ProzentValueTem + " der Werte liegen Im Wertebereich des Habitats");

            FeuchtigkeitDiagramm.Plot.XAxis.DateTimeFormat(true);
            FeuchtigkeitDiagramm.Plot.AddVerticalSpan(minfeu, maxfeu, System.Drawing.Color.LightBlue);
            FeuchtigkeitDiagramm.Plot.AddScatter(dataDatum, dataFeuchtigkeit);
            FeuchtigkeitDiagramm.Plot.Title("Feuchtigkeitsverlauf Kalmien-Deutzie"); // Title
            FeuchtigkeitDiagramm.Plot.XLabel(ProzentValue + " der Werte liegen Im Wertebereich des Habitats");
        }
    }
}
