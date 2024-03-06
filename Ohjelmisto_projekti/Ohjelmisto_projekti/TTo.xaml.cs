using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Ohjelmisto_projekti;

namespace Ohjelmisto_projekti
{
    public partial class TTo : Window
    {
        public TTo()
        {
            InitializeComponent();
        }

        private void MaLisays_Click(object sender, RoutedEventArgs e)
        {
            string Liike = Liike1.Text;
            string Pituus = Pituus1.Text;
            string Paino = Paino1.Text;

            // Tarkistetaan että on kaikkiin annettu jotain arvoja
            if (IsValidInput(Liike, Pituus, Paino))
            {
                SarjaStorage.LisaaSarja(new Sarja(Liike, Pituus, Paino));
                Paivittaja();
                Liike1.Text = "";
                Pituus1.Text = "";
                Paino1.Text = "";
            }
            else
            {
                MessageBox.Show("Anna kenttiin oikeat arvot. Painoon max 3 numeroa. Pituuteen max 2 numeroa. Vain numeroita näihin kahteen kenttään ", "Virhe ilmoitus");
            }
        }

        private bool IsValidInput(string liike, string pituus, string paino)
        {
            if (string.IsNullOrEmpty(liike))
                return false;
            if (!pituus.All(char.IsDigit) || pituus.Length > 2)
                return false;
            if (!paino.All(char.IsDigit) || paino.Length > 3)
                return false;

            return true;
        }

        private void PoistaTreeni_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = (int)button.Tag;
            SarjaStorage.PoistaSarja(index);
            Paivittaja();
        }

        private void Paivittaja()
        {
            WrapPanelOmaLiike.Children.Clear();
            for (int i = 0; i < SarjaStorage.Sarjat.Count; i++)
            {
                Sarja sarja = SarjaStorage.Sarjat[i];
                StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };
                TextBlock textBlock = new TextBlock { Text = $"{i + 1}. {sarja.Liike} - {sarja.Pituus} Toistoa - {sarja.Paino} KG", FontSize = 14 };
                Button button = new Button { Content = "X", Tag = i, Margin = new Thickness(5, 0, 0, 0), };
                button.Click += PoistaTreeni_Click;
                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(button);
                button.Background = System.Windows.Media.Brushes.Transparent;
                button.BorderBrush = null;
                button.Foreground = System.Windows.Media.Brushes.Red;
                WrapPanelOmaLiike.Children.Add(stackPanel);
            }
        }
    }
}
