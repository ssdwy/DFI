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
    /// AutomatischeHabitatEmpfehlung.xaml 的交互逻辑
    /// </summary>
    public partial class AutomatischeHabitatEmpfehlung : Window
    {
        public AutomatischeHabitatEmpfehlung()
        {
            InitializeComponent();
            UpadateHabitatempfehlungDatagrid();
        }
        public void UpadateHabitatempfehlungDatagrid()
        {
            HabitatempfehlungDatagrid.Items.Clear();
            List<HabitatPflanze> habitatPflanzes = new List<HabitatPflanze>();

            foreach (Pflanze pflanze in PflanzeRepo.ReadAll())
            {
                int maxtem = HabitatRepo.MaxTem(pflanze)[0];
                int mintem = HabitatRepo.MinTem(pflanze)[0];
                int maxfeu = HabitatRepo.MaxFeu(pflanze)[0];
                int minfeu = HabitatRepo.MinFeu(pflanze)[0];
                List<int> SensorData = SensorRepo.GetSensorData(pflanze);
                List<double> Fkeit = new List<double>();
                List<double> Tem = new List<double>();
                List<string> optimale_Habitat = new List<string>();

                int i_original_feu = 0; 
                int i_original_tem = 0;
                int i_all_fue_opt = 0;
                int i_all_tem_opt = 0;
                foreach (Messung messung in MessungRepo.GetMessungData(SensorData[0]))
                {
                    Fkeit.Add(messung.Mes_Feuchtigkeit);
                    Tem.Add(messung.Mes_Temperatur);

                    if (messung.Mes_Feuchtigkeit > minfeu && messung.Mes_Feuchtigkeit < maxfeu)
                    {
                        i_original_feu++;
                    }
                    if (messung.Mes_Temperatur > mintem && messung.Mes_Temperatur < maxtem)
                    {
                        i_original_tem++;
                    }

                    // Iterieren Sie durch die Datenbank für alle höchsten Temperaturen des Habitats sowie die niedrigsten Temperaturen.
                    foreach (Habitat habitat in HabitatRepo.ReadAll())
                    {
                        int maxtem_all = habitat.Hab_TemperaturMax;
                        int mintem1_all = habitat.Hab_TemperaturMin;
                        int maxfeu1_all = habitat.Hab_FeuchtigkeitMax;
                        int minfeu1_all = habitat.Hab_FeuchtigkeitMin;

                        int i_all_fue = 0;
                        int i_all_tem = 0;

                        if (messung.Mes_Feuchtigkeit > minfeu1_all && messung.Mes_Feuchtigkeit < maxfeu1_all)
                        {
                            i_all_fue++;
                        }
                        if (messung.Mes_Temperatur > mintem1_all && messung.Mes_Temperatur < maxtem_all)
                        {
                            i_all_tem++;
                        }
                        if(i_all_fue + i_all_tem > i_all_fue_opt + i_all_tem_opt)
                        {
                            i_all_fue_opt = i_all_fue;
                            i_all_tem_opt = i_all_tem;
                            optimale_Habitat.Clear();
                            optimale_Habitat.Add(habitat.Hab_Bezeichnung);
                        }

                    }
                }
                double[] dataFeuchtigkeit = Fkeit.ToArray();
                double[] dataTemperatur = Tem.ToArray();
                double Prozent = Math.Round((double)i_original_feu / dataFeuchtigkeit.Length, 2);
                string ProzentValue = (Prozent).ToString("0%"); // Originale Feuchtigkeit Prozent
                double ProzentTem = Math.Round((double)i_original_tem / dataTemperatur.Length, 2);
                string ProzentValueTem = (ProzentTem).ToString("0%"); // Originale Temperatur Prozent

                double Prozent_optimal = Math.Round((double)i_all_fue_opt / dataFeuchtigkeit.Length, 2);
                string ProzentValue_optimal = (Prozent_optimal).ToString("0%"); // Optimale Feuchtigkeit Prozent
                double ProzentTem_optimal = Math.Round((double)i_all_tem_opt / dataTemperatur.Length, 2);
                string ProzentValueTem_optimal = (ProzentTem_optimal).ToString("0%"); // Optimale Temperatur Prozent

                string optiamle_Habitatst = optimale_Habitat[0].ToString();

                bool doppelterEintrag = false;
                bool Ist_op = false;
                
                //foreach (Habitat habitat1 in HabitatRepo.Readhabitats(pflanze))
                //{
                //    foreach (HabitatPflanze hp in habitatPflanzes)
                //    {
                //        if (hp.Pflanze.Pfl_Hab_ID == pflanze.Pfl_Hab_ID && hp.Habitat.Hab_ID == habitat1.Hab_ID)
                //        {
                //            doppelterEintrag = true;
                //            break;
                //        }
                //    }
                //    if (optiamle_Habitatst == habitat1.Hab_Bezeichnung)
                //    {
                //        Ist_op = true;
                //    }
                //    if (! doppelterEintrag)
                //    {
                //        habitatPflanzes.Add(new HabitatPflanze(habitat1, pflanze, optiamle_Habitatst, Ist_op));
                //    }
                //}

            }
            foreach (HabitatPflanze habitatPflanze11 in habitatPflanzes)
            {
                HabitatempfehlungDatagrid.Items.Add(habitatPflanze11);
            }

        }
    }
}
