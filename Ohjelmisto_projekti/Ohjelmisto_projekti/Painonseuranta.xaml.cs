using ScottPlot;
using ScottPlot.AxisPanels;
using ScottPlot.Plottables;
using ScottPlot.TickGenerators;
using ScottPlot.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
            InitializeComponent();

            calendar.SelectedDate = DateTime.Now;

            double[] dataX = { 1, 2, 3, 4, 5, 6, 7 };
            WpfPlot1.Plot.Axes.DateTimeTicksBottom();
            WpfPlot1.Plot.Axes.SetLimits(1, 7, 60, 100);
            WpfPlot1.Plot.Axes.Bottom.MajorTickStyle.Length = 10;
            WpfPlot1.Plot.Axes.Bottom.MajorTickStyle.Width = 2;

            WpfPlot1.Plot.Style.ColorAxes(ScottPlot.Color.FromHex("#ff9100"));

            WpfPlot1.Refresh();

            PaivitaPaino();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double weight;
            double.TryParse(paino.Text, out weight);

            DateTime date = calendar.SelectedDate ?? DateTime.MinValue;

            if (calendar.SelectedDate != DateTime.MinValue)
            {
                // Tarkista, onko valitulle päivämäärälle jo merkintä
                if (PaivaList.Any(entry => entry.date.Date == date.Date))
                {
                    MessageBox.Show("Tälle päivälle on jo olemassa merkintä. Valitse toinen päivä.");
                    return;
                }

                var selectedDate = calendar.SelectedDate ?? DateTime.MinValue;
                var newDateEntry = new PaivaLista(selectedDate);
                PaivaList.Add(newDateEntry);

                var newEntry = new Painoni(weight);
                PainoLista.Add(newEntry);

                var weights = PainoLista.Select(entry => entry.paino).ToArray();//weights muuttuu arrayksi joka hakee PainoListalta arvonsa
                var dates = PaivaList.Select(entry => entry.date.ToOADate()).ToArray();//dates muuttuu manuaalisesti floating-point numeroksi



                if (weights.Length == dates.Length)
                {
                    WpfPlot1.Plot.Clear();
                    WpfPlot1.Plot.Add.Scatter(dates, weights); //weights ja dates käytetään y ja x arvoina diagrammissa
                    var scatter = WpfPlot1.Plot.Add.Scatter(dates, weights); // Add scatter plot and capture it in a variable
                    scatter.Color = ScottPlot.Color.FromHex("#ff002f"); // Set scatter color to red
                    scatter.LineWidth = 2;


                    WpfPlot1.Plot.RenderManager.RenderStarting += (s, e) =>
                    {
                        Tick[] ticks = WpfPlot1.Plot.Axes.Bottom.TickGenerator.Ticks;
                        for (int i = 0; i < ticks.Length; i++)
                        {
                            DateTime dt = DateTime.FromOADate(ticks[i].Position);
                            string label = $"{dt:dd/MM/yyy}";
                            ticks[i] = new Tick(ticks[i].Position, label);
                        }
                    };

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
            var sortedEntries = PaivaList.Zip(PainoLista, (dateEntry, weightEntry) => new { DateEntry = dateEntry, WeightEntry = weightEntry })
                                  .OrderBy(entry => entry.DateEntry.date)
                                  .ToList();

            var stringBuilder = new StringBuilder();

            foreach (var entry in sortedEntries)
            {
                var entryDate = entry.DateEntry.date.ToString("dd/MM/yyyy");
                var entryWeight = entry.WeightEntry.paino + "kg";
                stringBuilder.AppendLine($"({entryDate}) {entryWeight}");
            }

            textBlock.Text = stringBuilder.ToString();
        }

    }
}