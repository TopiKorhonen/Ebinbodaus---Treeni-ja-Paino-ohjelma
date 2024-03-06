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
using System.Windows.Shapes;

namespace Ohjelmisto_projekti
{
    /// <summary>
    /// Interaction logic for TTi.xaml
    /// </summary>
    public partial class TTi : Window
    {
        List<Sarja> Sarjat = new List<Sarja>();
        public TTi()
        {
            InitializeComponent();
        }

        private void MaLisays_Click(object sender, RoutedEventArgs e)
        {
            string Liike = string.Empty;
            string Pituus = string.Empty;
            string Paino = string.Empty;
            if (!string.IsNullOrEmpty(Liike1.Text))
                Liike = Liike1.Text;
            if (!string.IsNullOrEmpty(Pituus1.Text))
                Pituus = Pituus1.Text;
            if (!string.IsNullOrEmpty(Paino1.Text))
                Paino = Paino1.Text;
            if (!string.IsNullOrEmpty(Pituus) && !string.IsNullOrEmpty(Pituus) && !string.IsNullOrEmpty(Paino))
            {
                var UusiSarja = new Sarja(Liike, Pituus, Paino);
                Sarjat.Add(UusiSarja);
            }
            Paivittaja();
        }
        public void Paivittaja()
        {
            var stringi = "";
            foreach (var Sarja in Sarjat)
                stringi += $" {Sarja.Liike} - {Sarja.Pituus} Toistoa  -  {Sarja.Paino}KG /n";
            OmaLiike.Text = stringi;
        }
    }
}

