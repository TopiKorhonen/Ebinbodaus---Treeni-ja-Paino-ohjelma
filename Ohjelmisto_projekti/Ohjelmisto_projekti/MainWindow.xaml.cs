using Ohjelmisto_projekti;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Navigation_Drawer_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
      
        private void Treenit_Click(object sender, RoutedEventArgs e)
        {
            Treenit myWindow = new();
            if (myWindow.ShowDialog() == true) ;
        }
        private void PainoOsio_Click(object sender, RoutedEventArgs e)
        {
            Painonseuranta myWindow = new();
            if (myWindow.ShowDialog() == true) ;
        }
        private void Paaruutu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow myWindow = new();
            if (myWindow.ShowDialog() == true) ;
        }
    }
}
