using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Ohjelmisto_projekti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Painoni> PainoLista = new List<Painoni>();
        public MainWindow()
        {
            InitializeComponent();
            double[] dataX = { 1, 2, 3, 4, 5, 6, 7 };
            double[] dataY = { 76.4, 77.2, 72.5, 77, 79.2 };
            WpfPlot1.Plot.Add.Scatter(dataX, dataY);
            WpfPlot1.Refresh();

            
            
            PaivitaPaino();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = string.Empty;
            int weight;
            string ruffness = string.Empty;
            int grade;


            int.TryParse(paino.Text, out weight);
            int.TryParse(paivamaaraa.Text, out grade);

            if (weight + grade > 0)
            {
                var newRock = new Painoni(weight, grade);
                PainoLista.Add(newRock);
            }
            PaivitaPaino();
            
        }
        public void PaivitaPaino()
        {
            var stringgi = "";
            foreach (var kivi in PainoLista)
                stringgi += $"[{kivi.tunnisteTieto}]  ({kivi.paino}kg) - ({kivi.paivamaaraa}Päivämäärä) \n";
            listasto.Text = stringgi;
        }
    }
}