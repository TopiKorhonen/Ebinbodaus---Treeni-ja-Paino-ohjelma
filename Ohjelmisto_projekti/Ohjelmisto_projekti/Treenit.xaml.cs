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

        private void Maanantai_Click(object sender, RoutedEventArgs e)
        {
            if (this is MainWindow)
            {
                this.Close();
            }
            else
            {
                TMa mainWindow = new TMa();
                mainWindow.Show();
                this.Close();
            }
        }
        private void Perjantai_Click_1(object sender, RoutedEventArgs e)
        {
            if (this is MainWindow)
            {
                this.Close();
            }
            else
            {
                TPe mainWindow = new TPe();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Tiistai_Click_1(object sender, RoutedEventArgs e)
        {
            if (this is MainWindow)
            {
                this.Close();
            }
            else
            {
                TTo mainWindow = new TTo();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Lauantai_Click_1(object sender, RoutedEventArgs e)
        {
            if (this is MainWindow)
            {
                this.Close();
            }
            else
            {
                TLa mainWindow = new TLa();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Sunnuntai_Click_1(object sender, RoutedEventArgs e)
        {
            if (this is MainWindow)
            {
                this.Close();
            }
            else
            {
                TSu mainWindow = new TSu();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Torstai_Click_1(object sender, RoutedEventArgs e)
        {
            if (this is MainWindow)
            {
                this.Close();
            }
            else
            {
                TTo mainWindow = new TTo();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Keskiviikko_Click_1(object sender, RoutedEventArgs e)
        {
            if (this is MainWindow)
            {
                this.Close();
            }
            else
            {
                TKe mainWindow = new TKe();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
