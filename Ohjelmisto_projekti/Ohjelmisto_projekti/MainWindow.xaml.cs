﻿using Newtonsoft.Json;
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

namespace Navigation_Drawer_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;

        public MainWindow()
        {
            InitializeComponent();
            string jsonFilePath = "data.json";
            string jsonText = File.ReadAllText(jsonFilePath);
            var data = JsonConvert.DeserializeObject<Dictionary<string, double>>(jsonText);

            // Koita nyt tähän saada vikat 7pv jsonista
            var last7Days = data
                .OrderByDescending(kv => DateTime.Parse(kv.Key))
                .Take(7)
                .OrderBy(kv => DateTime.Parse(kv.Key))
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            // viivadiagrammi?
            WpfPlot1.Plot.Title("Weight Over Last 7 Days");
            WpfPlot1.Plot.YLabel("Weight");
            WpfPlot1.Plot.XLabel("Date");

            // Se data siite plotinperkuleeseen
            double[] painot = last7Days.Values.ToArray();
            string[] paivat = last7Days.Keys.ToArray();

            // Plot the data
            WpfPlot1.Plot.Add.Scatter(paivat , painot);
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
