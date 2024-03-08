using Newtonsoft.Json;
using Ohjelmisto_projekti;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.IO;
using ScottPlot;

namespace Navigation_Drawer_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Painoni> PainoLista = new List<Painoni>();
        private List<PaivaLista> PaivaList = new List<PaivaLista>();

        private static MainWindow instance;

        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromJson();
            PlotData();
        }
        private void PlotData()
        {
            // Valitaan vain viimeiset 7 päivää sisältävät merkinnät
            var last7DaysEntries = PaivaList
                .Where(entry => (DateTime.Now - entry.date).TotalDays < 7)
                .OrderByDescending(entry => entry.date)
                .ToList();

            // Rajataan merkinnät maksimissaan 7 päivään
            if (last7DaysEntries.Count > 7)
                last7DaysEntries = last7DaysEntries.Take(7).ToList();

            // Järjestetään merkinnät päivämäärän mukaan
            var sortedEntries = last7DaysEntries.Zip(PainoLista, (dateEntry, weightEntry) => new { DateEntry = dateEntry, WeightEntry = weightEntry })
                .OrderBy(entry => entry.DateEntry.date)
                .ToList();

            // Valmistellaan data kaavion piirtämistä varten
            var sortedWeights = sortedEntries.Select(entry => entry.WeightEntry.paino).ToArray();
            var sortedDates = sortedEntries.Select(entry => entry.DateEntry.date).ToArray();

            // Tyhjennetään nykyinen kaavio ennen uuden datan lisäämistä
            WpfPlot1.Plot.Clear();

            // Lisätään kaavioon pistekaavio (scatter plot) järjestetyillä päivämäärillä ja painoilla
            var scatter = WpfPlot1.Plot.Add.Scatter(sortedDates, sortedWeights);
            scatter.Color = ScottPlot.Color.FromHex("#b5ff66");
            scatter.LineWidth = 5;
            scatter.MarkerSize = 13;

            // Asetetaan kaaviolle päivämäärätickien muotoilu
            WpfPlot1.Plot.RenderManager.RenderStarting += (s, e) =>
            {
                Tick[] ticks = WpfPlot1.Plot.Axes.Bottom.TickGenerator.Ticks;
                for (int i = 0; i < ticks.Length; i++)
                {
                    DateTime dt = DateTime.FromOADate(ticks[i].Position);
                    string label = $"{dt:dd/MM/yyyy}";
                    ticks[i] = new Tick(ticks[i].Position, label);
                }
            };

            // Automaattinen skaalaus akselille
            WpfPlot1.Plot.Axes.AutoScale();
            // Päivitetään kaavio näyttämään uusi data
            WpfPlot1.Refresh();
        }
        private void LoadDataFromJson()
        {
            string filePath = "data.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var jsonData = JsonConvert.DeserializeObject<dynamic>(json);

                double[] dates = jsonData.Dates.ToObject<double[]>();
                double[] weights = jsonData.Weights.ToObject<double[]>();

                PaivaList.Clear();
                PainoLista.Clear();

                for (int i = 0; i < dates.Length; i++)
                {
                    PaivaList.Add(new PaivaLista(DateTime.FromOADate(dates[i])));
                    PainoLista.Add(new Painoni(weights[i]));
                }
            }
            else
            {
                MessageBox.Show("Data file not found.");
            }
        }

        public static MainWindow GetInstance()
        {
            if (instance == null)
            {
                instance = new MainWindow();
            }
            return instance;
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_koti.Visibility = Visibility.Collapsed;
                tt_treeni.Visibility = Visibility.Collapsed;
                tt_paino.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_koti.Visibility = Visibility.Visible;
                tt_treeni.Visibility = Visibility.Visible;
                tt_paino.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void Paaruutu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this is MainWindow)
            {
                this.Close();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
      
        private void Treenit_Click(object sender, RoutedEventArgs e)
        {
            Treenit secondWin = new Treenit();
            secondWin.Show();
            this.Close();
        }
        private void PainoOsio_Click(object sender, RoutedEventArgs e)
        {
            Painonseuranta secondWin = new Painonseuranta();
            secondWin.Show();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
