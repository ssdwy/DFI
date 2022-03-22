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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;


namespace DFI_UE4_Gruppe11
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Laden_Click(object sender, RoutedEventArgs e) // Button zum Laden der Datenbank
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "db files (*.db)|*.db|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TextBox_DatenbanklPath.Text = openFileDialog.FileName;
                    SQLiteBaseRepo.Dbfile = openFileDialog.FileName;
                    Fill_ComboBoxGewaechshaus();
                    UpadateHabitatempfehlungDatagrid();
                }
            }
        }
        public void Fill_ComboBoxGewaechshaus() // Gewaechshaus in ComboBox
        {
            foreach (Gewaechshaus gewaechshaus in GewaechshausRepo.ReadAll())
            {
                AusgewaehltGew_Combobox.Items.Add(gewaechshaus);
            }
            AusgewaehltGew_Combobox.SelectedIndex = 0;
        }

        public void UpdataDatagridPflanze() // Updata Dünger-undWasserbedarf sowie Die Pflanze_Bezeichnung in Datagrid
        {
            Planze_Datagrid.Items.Clear();

            Gewaechshaus gewaechshaus = (Gewaechshaus)AusgewaehltGew_Combobox.SelectedItem;

            foreach (Pflanze pflanze in PflanzeRepo.ReadAllPflanzeData(gewaechshaus))
            {
                Planze_Datagrid.Items.Add(pflanze);
            }
        }
        private void AusgewaehltGew_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Wenn die Änderung des Gewaechshauses
        {
            UpdataDatagridPflanze();
            UpdataDatagridGaernter();
        }
        private void Materialbedarf_Button_Click(object sender, RoutedEventArgs e) // Button von Materialbedarf falls klick
        {
            Materialbedarf mb = new Materialbedarf((Gewaechshaus)AusgewaehltGew_Combobox.SelectedItem);
            mb.ShowDialog();
        }
        private void Bearbeiten_Button_Click(object sender, RoutedEventArgs e) // Button von die Veränderung der Pflanze
        {
            if (Planze_Datagrid.SelectedItem != null)
            {
                bearbeiten bea = new bearbeiten((Pflanze)Planze_Datagrid.SelectedItem, (Gewaechshaus)AusgewaehltGew_Combobox.SelectedItem);
                bea.ShowDialog();
                UpdataDatagridPflanze();
            }
        }

        private void Neu_Button_Click(object sender, RoutedEventArgs e) // Button von eine Pflanze zu erstellen
        {
            Pflanze pflanze = new Pflanze();

            pflanze.Pfl_Gew_ID = ((Gewaechshaus)AusgewaehltGew_Combobox.SelectedItem).Gew_ID;

            bearbeiten bea = new bearbeiten(pflanze, (Gewaechshaus)AusgewaehltGew_Combobox.SelectedItem);
            bea.ShowDialog();
            UpdataDatagridPflanze();
        }

        private void Loeschen_Button_Click(object sender, RoutedEventArgs e) // Button von eine Pflanze zu loeschen
        {
            if (Planze_Datagrid.SelectedItem != null)
            {
                Pflanze selectedPflanze = (Pflanze)Planze_Datagrid.SelectedItem;
                PflanzeRepo.DeletePflanze(selectedPflanze);

                UpdataDatagridPflanze();
            }
        }
        public void UpdataDatagridGaernter() // Daten von Datagrid fuer Gaernter zu updaten
        {
            GarDatagrid.Items.Clear();

            foreach (Gaertner gaertner in GaertnerRepo.ReadAll())
            {
                GarDatagrid.Items.Add(gaertner);
            }
        }
        public void UpdataDatagridbetreut() // Updata von Datagrid von betreut 
        {
            betDatagrid.Items.Clear();
            List<GewBet> gewBets = new List<GewBet>();
            Gaertner gaertner = (Gaertner)GarDatagrid.SelectedItem;

            foreach (betreut betreut in betreutRepo.ReadAllbetreut(gaertner)) // Iterieren durch die in Frage kommenden Gärtner.
            {
                foreach (Gewaechshaus gewaechshaus in GewaechshausRepo.Readgae(betreut)) //Iterieren durch die in Frage kommenden Gewaechshaus
                {
                    bool doppelterEintrag = false;
                    foreach (GewBet g in gewBets)
                    {
                        if (g.Betreut.Bet_Datum == betreut.Bet_Datum && g.Betreut.Bet_Gae_ID == betreut.Bet_Gae_ID && g.Betreut.Bet_Gew_ID == betreut.Bet_Gew_ID)
                        {
                            doppelterEintrag = true;
                            break;
                        }
                    }
                    if (!doppelterEintrag)
                    {
                        gewBets.Add(new GewBet(betreut, gewaechshaus));
                    }
                }
            }
            IEnumerable<GewBet> gewBetssort = gewBets.OrderBy(g => g.Datum); // Sortiert

            foreach (GewBet gew in gewBetssort)
            {
                betDatagrid.Items.Add(gew);
            }
        }
        private void Gar_BearibeitenButton_Click(object sender, RoutedEventArgs e) // Button von Gaertner zu bearbeiten
        {
            if (GarDatagrid.SelectedItem != null) // Wenn es eine geselected
            {

                GaeBearbeiten gaeBearbeiten = new GaeBearbeiten((Gaertner)GarDatagrid.SelectedItem);
                gaeBearbeiten.ShowDialog();
                UpdataDatagridGaernter();
            }
        }
        private void GarDatagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e) // Wenn es einen ausgewählten Datagrid-Inhalt gibt
        {
            if (GarDatagrid.SelectedItem != null)
            {
                UpdataDatagridbetreut(); // Ausführen.
            }
        }
        private void Gar_NeuButton_Click(object sender, RoutedEventArgs e) // Button von ein neuer Gaertner erstellen
        {
            Gaertner gaertner = new Gaertner();

            GaeBearbeiten gaeBearbeiten = new GaeBearbeiten(gaertner);
            gaeBearbeiten.ShowDialog();
            UpdataDatagridGaernter();
        }

        private void Gar_LoeschenButton_Click(object sender, RoutedEventArgs e) // Button von ein neuer Gaertner loeschen
        {
            if (GarDatagrid.SelectedItem != null)
            {
                Gaertner Selectedgaetner = (Gaertner)GarDatagrid.SelectedItem;
                GaertnerRepo.DeleteGaertner(Selectedgaetner);
                UpdataDatagridGaernter();
            }
        }

        private void MesswerteAnzeigen_Button_Click(object sender, RoutedEventArgs e) //Button von Diagramm zu zeichnen
        {
            if (Planze_Datagrid.SelectedItem != null)
            {
                Messwerte messwerte = new Messwerte((Pflanze)Planze_Datagrid.SelectedItem);
                messwerte.ShowDialog();
            }
        }
        public void UpadateHabitatempfehlungDatagrid() // Updata von Teil2 der Aufgabe
        {
            HabitatempfehlungDatagrid.Items.Clear();
            List<HabitatPflanze> habitatPflanzes = new List<HabitatPflanze>();
            foreach (Pflanze pflanze in PflanzeRepo.ReadAll()) // Traversierung alle Pflanze
            {
                int maxtem = HabitatRepo.MaxTem(pflanze)[0]; // Maximale und minimale Temperatur- und Luftfeuchtigkeitswerte des Habitats
                int mintem = HabitatRepo.MinTem(pflanze)[0]; // Gleich oben
                int maxfeu = HabitatRepo.MaxFeu(pflanze)[0]; // Gleich oben
                int minfeu = HabitatRepo.MinFeu(pflanze)[0]; // Gleich oben
                List<int> SensorData = SensorRepo.GetSensorData(pflanze); // Sensor entsprechend der Pflanze
                List<string> optimale_Habitat = new List<string>();

                int i_original_feu = 0;
                int i_original_tem = 0;
                int i_all_fue_opt = 0;
                int i_all_tem_opt = 0;
                try
                {
                    foreach (Messung messung in MessungRepo.GetMessungData(SensorData[0])) // Iterieren durch alle Messwerte
                    {
                        if (messung.Mes_Feuchtigkeit > minfeu && messung.Mes_Feuchtigkeit < maxfeu) // Bestimmen Sie, wie viele Punkte in Messung die Anforderungen von Habitat erfüllen
                        {
                            i_original_feu++;
                        }
                        if (messung.Mes_Temperatur > mintem && messung.Mes_Temperatur < maxtem) // Gleich oben
                        {
                            i_original_tem++;
                        }
                    }
                    foreach (Habitat habitat in HabitatRepo.ReadAll()) // Iterieren Sie durch die Datenbank für alle höchsten Temperaturen des Habitats sowie die niedrigsten Temperaturen.
                    {
                        int maxtem_all = habitat.Hab_TemperaturMax; // Maximale und minimale Temperatur- und Luftfeuchtigkeitswerte des Habitats
                        int mintem1_all = habitat.Hab_TemperaturMin;
                        int maxfeu1_all = habitat.Hab_FeuchtigkeitMax;
                        int minfeu1_all = habitat.Hab_FeuchtigkeitMin;

                        int i_all_fue = 0;
                        int i_all_tem = 0;
                        foreach (Messung messung in MessungRepo.GetMessungData(SensorData[0]))
                        {
                            if (messung.Mes_Feuchtigkeit > minfeu1_all && messung.Mes_Feuchtigkeit < maxfeu1_all)
                            {
                                i_all_fue++;
                            }
                            if (messung.Mes_Temperatur > mintem1_all && messung.Mes_Temperatur < maxtem_all)
                            {
                                i_all_tem++;
                            }
                        }
                        if (i_all_fue + i_all_tem > i_all_fue_opt + i_all_tem_opt) // Optimale Habitat, wenn die Summe der Messpunkte von Temperatur und Feuchte, an denen die Pflanze die Anforderungen erfüllt, das Maximum ist
                        {
                            i_all_fue_opt = i_all_fue;
                            i_all_tem_opt = i_all_tem;
                            optimale_Habitat.Clear();
                            optimale_Habitat.Add(habitat.Hab_Bezeichnung);
                        }
                    }
                    string optiamle_Habitatst = optimale_Habitat[0].ToString(); // Ausgang Bestes Habitat

                    bool Ist_op = false;

                    foreach (Habitat habitat1 in HabitatRepo.Readhabitats(pflanze))
                    {
                        if (optiamle_Habitatst == habitat1.Hab_Bezeichnung) // Bestimmen Sie, ob sich die Pflanze jetzt im Optimalen Lebensraum befindet
                        {
                            Ist_op = true;
                        }
                        habitatPflanzes.Add(new HabitatPflanze(habitat1.Hab_Bezeichnung, pflanze.Pfl_Bezeichnung, optiamle_Habitatst, Ist_op));

                    }
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Fehlende Daten für neue Pflanze");
                }
                
            }
            foreach (HabitatPflanze habitatPflanze11 in habitatPflanzes)
            {
                HabitatempfehlungDatagrid.Items.Add(habitatPflanze11);
            }
        }
        private void OptimalEinstellenButton_Click(object sender, RoutedEventArgs e) // Update auf Optimales Habitat
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Sind Sie sicher, dass Sie diesen Vorgang durchführen wollen?", "Optimale Empfehlung", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    foreach (Pflanze pflanze in PflanzeRepo.ReadAll())
                    {
                        Console.WriteLine(pflanze.Pfl_Hab_ID);
                        int maxtem = HabitatRepo.MaxTem(pflanze)[0];
                        int mintem = HabitatRepo.MinTem(pflanze)[0];
                        int maxfeu = HabitatRepo.MaxFeu(pflanze)[0];
                        int minfeu = HabitatRepo.MinFeu(pflanze)[0];
                        List<int> SensorData = SensorRepo.GetSensorData(pflanze);

                        List<string> optimale_Habitat = new List<string>();

                        int i_original_feu = 0;
                        int i_original_tem = 0;
                        int i_all_fue_opt = 0;
                        int i_all_tem_opt = 0;
                        int habid = pflanze.Pfl_Hab_ID;
                        if (SensorData[0] < 40)
                        {
                            foreach (Messung messung in MessungRepo.GetMessungData(SensorData[0]))
                            {
                                if (messung.Mes_Feuchtigkeit > minfeu && messung.Mes_Feuchtigkeit < maxfeu)
                                {
                                    i_original_feu++;
                                }
                                if (messung.Mes_Temperatur > mintem && messung.Mes_Temperatur < maxtem)
                                {
                                    i_original_tem++;
                                }
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
                                foreach (Messung messung in MessungRepo.GetMessungData(SensorData[0]))
                                {
                                    if (messung.Mes_Feuchtigkeit > minfeu1_all && messung.Mes_Feuchtigkeit < maxfeu1_all)
                                    {
                                        i_all_fue++;
                                    }
                                    if (messung.Mes_Temperatur > mintem1_all && messung.Mes_Temperatur < maxtem_all)
                                    {
                                        i_all_tem++;
                                    }
                                }
                                if (i_all_fue + i_all_tem > i_all_fue_opt + i_all_tem_opt)
                                {
                                    i_all_fue_opt = i_all_fue;
                                    i_all_tem_opt = i_all_tem;
                                    optimale_Habitat.Clear();
                                    optimale_Habitat.Add(habitat.Hab_Bezeichnung);
                                    habid = habitat.Hab_ID;
                                    pflanze.Pfl_Hab_ID = habid;
                                }
                                PflanzeRepo.UpdatePflanze(pflanze);
                            }
                        }
                    }
                }
                catch
                {
                }
                UpadateHabitatempfehlungDatagrid();
                System.Windows.Forms.MessageBox.Show("Erfolgreich geändert");
            }
        }
    }
}
