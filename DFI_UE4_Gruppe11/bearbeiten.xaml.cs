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
    /// bearbeiten.xaml 的交互逻辑
    /// </summary>
    public partial class bearbeiten : Window
    {
        Pflanze pflanze;
        Gewaechshaus Gewaechshaus;
        public bearbeiten(Pflanze pflanze, Gewaechshaus gewaechshaus)
        {
            InitializeComponent();
            Fill_ComboBoxGewaechshaus();
            Fill_HabCombobox();
            this.pflanze = pflanze;
            this.Gewaechshaus = gewaechshaus;
            if (pflanze.Pfl_ID != 0) // Bearbeiten wenn eine Pflanze in Datagrid ausgewaehlt
            {
                be_BezeichnungTextbox.Text = pflanze.Pfl_Bezeichnung;
                be_GewaechshausCombobox.SelectedIndex = pflanze.Pfl_Gew_ID - 1;
                HabCombobox.SelectedIndex = pflanze.Pfl_Hab_ID - 1;
                be_WasserverbrauchTextbox.Text = pflanze.Pfl_Wasserverbrauch.ToString();
                be_DuengerverbrauchTextbox.Text = pflanze.Pfl_Duengerverbrauch.ToString();
            }
            else // Neu erstellen
            {
                be_GewaechshausCombobox.SelectedIndex = 0;
                HabCombobox.SelectedIndex = 0;
            }
        }
        public void Fill_ComboBoxGewaechshaus()
        {
            foreach (Gewaechshaus gewaechshaus in GewaechshausRepo.ReadAll())
            {
                be_GewaechshausCombobox.Items.Add(gewaechshaus);
            }
        }
        public void Fill_HabCombobox()
        {
            foreach (Habitat habitat in HabitatRepo.ReadAll())
            {
                HabCombobox.Items.Add(habitat);
            }
        }
        private void OKButton_Click(object sender, RoutedEventArgs e) // Bestaetigen
        {
            if(be_BezeichnungTextbox.Text != "" && be_WasserverbrauchTextbox.Text != "" && be_DuengerverbrauchTextbox.Text != "")
            {
                pflanze.Pfl_Bezeichnung = be_BezeichnungTextbox.Text;
                pflanze.Pfl_Wasserverbrauch = Int32.Parse(be_WasserverbrauchTextbox.Text);
                pflanze.Pfl_Duengerverbrauch = Int32.Parse(be_DuengerverbrauchTextbox.Text);
                pflanze.Pfl_Gew_ID = ((Gewaechshaus)be_GewaechshausCombobox.SelectedItem).Gew_ID;
                pflanze.Pfl_Hab_ID = ((Habitat)HabCombobox.SelectedItem).Hab_ID;
                if (pflanze.Pfl_ID != 0) // Updata
                {
                    PflanzeRepo.UpdatePflanze(pflanze);
                }
                else // neu erstellen
                {
                    PflanzeRepo.InsertPflanze(pflanze);
                }

                Close();
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Wert ein.");
            }
        }
    }
}
