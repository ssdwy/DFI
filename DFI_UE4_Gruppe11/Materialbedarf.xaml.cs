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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Materialbedarf: Window
    {
        Gewaechshaus gewaechshaus1;
        public Materialbedarf(Gewaechshaus gewaechshaus)
        {
            InitializeComponent();
            this.gewaechshaus1 = gewaechshaus;

            Gew_BezeichnungTextbox.Text = gewaechshaus.Gew_Bezeichnung; // TextBox ausfüllen
            Gew_AdresseTextbox.Text = gewaechshaus.Gew_Strasse + gewaechshaus.Gew_Hausnummer; // Gleich oben
            Anzahl_PflanzeTextbox.Text = PflanzeRepo.CountPflanzeAnzahle(gewaechshaus)[0].ToString(); // Gleich oben
        }
        public void Dayscount(object sender, RoutedEventArgs e)
        {
            // Abrufen der vom Benutzer gewählten Zeit
            DateTime anfang = DatumZeit_Von.SelectedDate.HasValue? DatumZeit_Von.SelectedDate.Value: new DateTime(1970 / 1 / 1);
            DateTime end = DatumZeit_bis.SelectedDate.HasValue? DatumZeit_bis.SelectedDate.Value: new DateTime(1970 / 1 / 1);
            // Zeitverschiebung
            TimeSpan timeSpan = end - anfang;
            if (timeSpan.Days > 0) // Wenn die Zeitdifferenz größer als 0 ist
            {
                if (anfang != new DateTime(1970 / 1 / 1)) // Auch die Startzeit wird eingestellt
                {
                    WasserverbrauchTextBox.Text = PflanzeRepo.SumPflanzeWasserverbrauch(gewaechshaus1, (timeSpan.Days))[0].ToString();
                    DuengerverbrauchTextbox.Text = PflanzeRepo.SumPflanzeDuengerverbrauch(gewaechshaus1, (timeSpan.Days))[0].ToString();
                }
            }
            else if (timeSpan.Days <0) // Wenn weniger als 0
            {
                if (anfang != new DateTime(1970 / 1 / 1) && end != new DateTime(1970 / 1 / 1)) //Wenn beide Zeiten eingestellt sind
                {
                    MessageBox.Show("Das Startdatum sollte vor dem Enddatum liegen, bitte wählen Sie das entsprechende Datum neu aus.");
                }
                else if (anfang == new DateTime(1970 / 1 / 1) && end != new DateTime(1970 / 1 / 1)) //Wenn die Startzeit nicht eingestellt ist
                {
                    MessageBox.Show("Bitte wählen Sie das Startdatum aus.");
                }
            }           
        }
    }
}
