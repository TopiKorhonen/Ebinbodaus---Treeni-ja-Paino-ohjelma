using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Ohjelmisto_projekti
{
    public partial class TMa : Window
    {
        private List<Sarja> Sarjat = new List<Sarja>();

        public TMa()
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
                Sarjat.Add(new Sarja(Liike, Pituus, Paino));
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

        // Tarkistaa että on annettu oikeat arvot kaikkiin
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

        // Treenin  poisto nappi
        private void PoistaTreeni_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = (int)button.Tag;
            Sarjat.RemoveAt(index);
            Paivittaja();
        }

        // Päivittää näkymää
        private void Paivittaja()
        {
            WrapPanelOmaLiike.Children.Clear();
            for (int i = 0; i < Sarjat.Count; i++)
            {
                Sarja sarja = Sarjat[i];
                // Luodaan StackPaneliin treeni
                StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };
                TextBlock textBlock = new TextBlock { Text = $"{i + 1}. {sarja.Liike} - {sarja.Pituus} Toistoa - {sarja.Paino} KG", FontSize = 14 };
                // Luodaan poistanappi jokaiselle treenille
                Button button = new Button { Content = "X", Tag = i, Margin = new Thickness(5, 0, 0, 0), };
                button.Click += PoistaTreeni_Click;
                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(button);
                //Muokattiin hieman napin ulkonäköä 
                button.Background = System.Windows.Media.Brushes.Transparent;
                button.BorderBrush = null;
                button.Foreground = System.Windows.Media.Brushes.Red;
                WrapPanelOmaLiike.Children.Add(stackPanel);
            }
        }

    }
}
