using Navigation_Drawer_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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

namespace Ohjelmisto_projekti
{
    /// <summary>
    /// Interaction logic for Treenit.xaml
    /// </summary>
    public partial class Treenit : Window
    {
        public Treenit()
        {
            InitializeComponent();
        }


        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

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
            Treenit newWin = new Treenit();
            newWin.Show();
            this.Close();
        }
        private void PainoOsio_Click(object sender, RoutedEventArgs e)
        {
            Painonseuranta newWin = new Painonseuranta();
            newWin.Show();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Maanantai_Click(object sender, RoutedEventArgs e)
        {
            TMa myWindow = new();
            if (myWindow.ShowDialog() == true);
        }

        private void Tiistai_Click(object sender, RoutedEventArgs e)
        {
            TTi myWindow = new();
            if (myWindow.ShowDialog() == true) ;
        }

        private void Keskiviikko_Click(object sender, RoutedEventArgs e)
        {
            TKe myWindow = new();
            if (myWindow.ShowDialog() == true) ;
        }

        private void Torstai_Click(object sender, RoutedEventArgs e)
        {
            TTo myWindow = new();
            if (myWindow.ShowDialog() == true) ;
        }

        private void Perjantai_Click(object sender, RoutedEventArgs e)
        {
            TPe myWindow = new();
            if (myWindow.ShowDialog() == true) ;
        }

        private void Lauantai_Click(object sender, RoutedEventArgs e)
        {
            TLa myWindow = new();
            if (myWindow.ShowDialog() == true) ;
        }

        private void Sunnuntai_Click(object sender, RoutedEventArgs e)
        {
            TSu myWindow = new();
            if (myWindow.ShowDialog() == true) ;
        }
    }
}
