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
    /// GaeBearbeiten.xaml 的交互逻辑
    /// </summary>
    public partial class GaeBearbeiten : Window
    {
        Gaertner gaertner;
        public GaeBearbeiten(Gaertner gaertner)
        {
            InitializeComponent();
            this.gaertner = gaertner;

            if (gaertner.Gae_ID != 0)
            {
                NachnameTextbox.Text = gaertner.Gae_Nachname;
                VornahmeTextbox.Text = gaertner.Gae_Vorname;
                StandCheckbox.IsChecked = gaertner.Gae_Aktiv;
            }
        }
        private void GaeOkButton_Click(object sender, RoutedEventArgs e) // Button von bestaetigen
        {
            if (NachnameTextbox.Text !="" && VornahmeTextbox.Text != "")
            {
                gaertner.Gae_Nachname = NachnameTextbox.Text;
                gaertner.Gae_Vorname = VornahmeTextbox.Text;
                gaertner.Gae_Aktiv = (bool)StandCheckbox.IsChecked;
                if (gaertner.Gae_ID != 0)
                {
                    GaertnerRepo.UpdateGaertner(gaertner);
                }
                else
                {
                    GaertnerRepo.InsertGaetner(gaertner);
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
