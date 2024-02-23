using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Ohjelmisto_projekti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Painonseuranta : Window
    {
        private List<Painoni> PainoLista = new List<Painoni>();
        List<PaivaLista> PaivaList = new List<PaivaLista>();
        public Painonseuranta()
        {
            

            double[] dataX = { 1, 2, 3, 4, 5, 6, 7 };
            WpfPlot1.Plot.Axes.DateTimeTicksBottom();
            WpfPlot1.Plot.Axes.SetLimits(1, 7, 60, 100);
            WpfPlot1.Plot.Axes.Bottom.MajorTickStyle.Length = 10;
            WpfPlot1.Plot.Axes.Bottom.MajorTickStyle.Width = 2;

            WpfPlot1.Plot.Style.ColorAxes(ScottPlot.Color.FromHex("#ff9100"));
            WpfPlot1.Refresh();

            PaivitaPaino();

        }

        private int lastEnteredDay = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double weight;
            double.TryParse(paino.Text, out weight);

            DateTime date = calendar.SelectedDate ?? DateTime.MinValue;
            // Get the selected date from the DatePicker



            if (calendar.SelectedDate != DateTime.MinValue)
            {
                var selectedDate = calendar.SelectedDate ?? DateTime.MinValue;

                var newDateEntry = new PaivaLista(selectedDate);
                PaivaList.Add(newDateEntry);

                var newEntry = new Painoni(weight);
                PainoLista.Add(newEntry);

                var weights = PainoLista.Select(entry => entry.paino).ToArray();//weights muuttuu arrayksi joka hakee PainoListalta arvonsa
                var dates = PaivaList.Select(entry => entry.date).ToArray();

                if (weights.Length == dates.Length)
                {
                    WpfPlot1.Plot.Clear();
                    WpfPlot1.Plot.Add.Scatter(dates, weights); //weights ja dates käytetään y ja x arvoina diagrammissa
                    var scatter = WpfPlot1.Plot.Add.Scatter(dates, weights); // Add scatter plot and capture it in a variable
                    scatter.Color = ScottPlot.Color.FromHex("#ff002f"); // Set scatter color to red
                    scatter.LineWidth = 2;

                    WpfPlot1.Plot.Axes.AutoScale();
                    WpfPlot1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Virheellinen syöte. Anna kelvollinen paino (kg) ja päivämäärä (1-7).");
            }
            PaivitaPaino();
            paino.Clear();
        }
        public void PaivitaPaino()
        {
            var stringgi = "";
            foreach (var entry in PaivaList)
                stringgi += $" ({entry.date.ToString("dd/MM/yyyy")})"; //ADD TUNNISTETIETO FROM PAIVALISTA

            foreach (var entry in PainoLista)
                stringgi += $" {entry.paino}kg";

            textBlock.Text = stringgi;
        }

    }
}