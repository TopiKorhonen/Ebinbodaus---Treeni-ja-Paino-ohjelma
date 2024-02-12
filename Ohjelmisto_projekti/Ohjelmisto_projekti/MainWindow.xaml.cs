using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
    public partial class MainWindow : Window
    {
        private List<Painoni> PainoLista = new List<Painoni>();
        private double[] dataY = null; //dataY on määritelty null 
        public MainWindow()
        {
            InitializeComponent();
            
            double[] dataX = { 1, 2, 3, 4, 5, 6, 7 };
            
            WpfPlot1.Plot.Style.ColorAxes(ScottPlot.Color.FromHex("#ff9100"));
            WpfPlot1.Plot.Add.Scatter(dataX, dataY ?? new double[0]);               //Jos dataY ei ole null, sitä käytetään Y-koordinanttina scatter plotissa
                                                                                    //jos dataY on null käytetään uutta tyhjää arrayta (new double[0])
                                                                                    //täten scatter plotissa on aina oikeaa dataa ja mahdollinen null ref ei synny.

            WpfPlot1.Plot.Axes.SetLimits(1, 7, 60, 100);
            WpfPlot1.Plot.Axes.Bottom.MajorTickStyle.Length = 10;
            WpfPlot1.Plot.Axes.Bottom.MajorTickStyle.Width = 2;
            WpfPlot1.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericFixedInterval(1);                                                   

            WpfPlot1.Refresh();

            PaivitaPaino();

        }

        private int lastEnteredDay = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double weight;
            int date;

            double.TryParse(paino.Text, out weight);
            int.TryParse(paivamaaraa.Text, out date);

            if (weight > 0 && date > 0 && date <= 7) //painon on oltava enemmän kun 0 ja päivä 1-7 välillä
            {
                if (date <= lastEnteredDay)
                {
                    MessageBox.Show("Kyseinen päivä on jo listattu, valitse toinen päivä");
                }
                else
                {
                    var newEntry = new Painoni(weight, date);
                    PainoLista.Add(newEntry);

                    var weights = PainoLista.Select(entry => entry.paino).ToArray();//weights muuttuu arrayksi joka hakee PainoListalta arvonsa
                    var dates = PainoLista.Select(entry => entry.paiva).ToArray(); //dates muuttuu arrayksi joka hakee PainoListalta arvonsa

                    WpfPlot1.Plot.Clear();
                    WpfPlot1.Plot.Add.Scatter(dates, weights); //weights ja dates käytetään y ja x arvoina diagrammissa
                    var scatter = WpfPlot1.Plot.Add.Scatter(dates, weights); // Add scatter plot and capture it in a variable
                    scatter.Color = ScottPlot.Color.FromHex("#ff002f"); // Set scatter color to red
                    scatter.LineWidth = 2;

                    WpfPlot1.Plot.Axes.AutoScale();
                    WpfPlot1.Refresh();
                    
                    lastEnteredDay = date;
                }
                
            }
            else
            {
                MessageBox.Show("Virheellinen syöte. Anna kelvollinen paino (kg) ja päivämäärä (1-7).");
            }
            PaivitaPaino();
            paino.Clear();
            paivamaaraa.Clear();
        }
        public void PaivitaPaino()
        {
            var stringgi = "";
            foreach (var entry in PainoLista)
                stringgi += $" [{entry.tunnisteTieto}]  {entry.paino}kg - {entry.paiva}. Päivä \n";
            listasto.Text = stringgi;
        }

    }
}