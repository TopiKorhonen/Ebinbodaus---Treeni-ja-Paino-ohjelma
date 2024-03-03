using Navigation_Drawer_App;
using ScottPlot;
using Newtonsoft.Json;
using System.IO;
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
            WpfPlot1.Plot.Axes.Bottom.MajorTickStyle.Width = 3;
            WpfPlot1.Plot.Style.Background(figure: ScottPlot.Color.FromHex("#242424"), data: ScottPlot.Color.FromHex("#242424"));
            WpfPlot1.Plot.Style.ColorAxes(ScottPlot.Color.FromHex("#91276c"));
            WpfPlot1.Plot.Style.ColorGrids(ScottPlot.Color.FromHex("#242424"));

            LoadDataFromJson(); //Hakee tiedot json filestä
           

            PaivitaPaino();

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

                // Add loaded data to your lists
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
            
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void Paaruutu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = MainWindow.GetInstance();
            mainWindow.Show();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Treenit_Click(object sender, RoutedEventArgs e)
        {
            Treenit myWindow = new();
            myWindow.Topmost = true;
            if (myWindow.ShowDialog() == true) ;
        }
        private void PainoOsio_Click(object sender, RoutedEventArgs e)
        {
            Painonseuranta myWindow = new();
            myWindow.Topmost = true;
            if (myWindow.ShowDialog() == true) ;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double weight;
            if (!double.TryParse(paino.Text, out weight) || weight <= 0)
            {
                MessageBox.Show("Vi+rheellinen syöte. Anna kelvollinen paino (kg).");
                return;
            }

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
                    var sortedEntries = PaivaList.Zip(PainoLista, (dateEntry, weightEntry) => new { DateEntry = dateEntry, WeightEntry = weightEntry })
                              .OrderBy(entry => entry.DateEntry.date)
                              .ToList();

                    var sortedWeights = sortedEntries.Select(entry => entry.WeightEntry.paino).ToArray();
                    var sortedDates = sortedEntries.Select(entry => entry.DateEntry.date.ToOADate()).ToArray();

                    // Save data to JSON
                    SaveDataToJson(sortedDates, sortedWeights);

                    WpfPlot1.Plot.Clear();

                    var scatter = WpfPlot1.Plot.Add.Scatter(sortedDates, sortedWeights);
                    scatter.Color = ScottPlot.Color.FromHex("#b5ff66");
                    scatter.LineWidth = 5;
                    scatter.MarkerSize = 13;


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
            PaivitaPaino();
            paino.Clear();

        }
        private void SaveDataToJson(double[] dates, double[] weights)
        {
           
            var jsonData = new
            {
                Dates = dates,
                Weights = weights
            };

         
            string json = JsonConvert.SerializeObject(jsonData);


            string filePath = "data.json";

            File.WriteAllText(filePath, json);
   
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
