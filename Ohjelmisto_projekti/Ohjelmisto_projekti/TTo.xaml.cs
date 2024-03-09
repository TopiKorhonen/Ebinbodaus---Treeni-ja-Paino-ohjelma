﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Ohjelmisto_projekti;
using Newtonsoft.Json;
using System.IO;
using Navigation_Drawer_App;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Ohjelmisto_projekti
{
    public partial class TTo : Window
    {
        private List<Sarja> SarjaListTo = new List<Sarja>();
        public TTo()
        {
            InitializeComponent();
            LoadDataFromJson(); //haetaan tiedot jsonista hetikun käynnistyyy sovellus
            UpdateUI(); //Näyttää tiedot oikeassa Uissa, joka tässä tilanteessa on Stackpanelin sisällä olevat textboxit!
            Paivittaja();
        }

        private void MaLisays_Click(object sender, RoutedEventArgs e)
        {
            string Liike = Liike1.Text;
            string Pituus = Pituus1.Text;
            string Paino = Paino1.Text;

            // Tarkistetaan että on kaikkiin annettu jotain arvoja
            if (IsValidInput(Liike, Pituus, Paino))
            {
                Sarja sarja = new Sarja(Liike, Pituus, Paino);
                SarjaListTo.Add(sarja); // Add Sarja object to the list
                Paivittaja();
                Liike1.Text = "";
                Pituus1.Text = "";
                Paino1.Text = "";
                SaveDataToJson();
            }
            else
            {
                MessageBox.Show("Anna kenttiin oikeat arvot. Painoon max 3 numeroa. Pituuteen max 2 numeroa. Vain numeroita näihin kahteen kenttään ", "Virhe ilmoitus");
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this is MainWindow)
            {
                this.Close();
            }
            else
            {
                Treenit mainWindow = new Treenit();
                mainWindow.Show();
                this.Close();
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
        // Päivittää näkymää
        private void Paivittaja()
        {
            WrapPanelOmaLiike.Children.Clear();
            for (int i = 0; i < SarjaListTo.Count; i++)
            {
                // Luodaan StackPaneliin treeni
                Sarja sarja = SarjaListTo[i];
                StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };
                TextBlock textBlock = new TextBlock { Text = $"{sarja.Liike} - {sarja.Pituus} Toistoa - {sarja.Paino} KG", FontSize = 14 };
                // Luodaan poistanappi jokaiselle treenille
                Button button = new Button { Content = "X", Tag = i, Margin = new Thickness(5, 0, 0, 0), };
                button.Click += PoistaSarja_Click; // Lisätään PoistaSarja_Click suoraan tähän
                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(button);
                //Muokattiin hieman napin ulkonäköä 
                button.Background = System.Windows.Media.Brushes.Transparent;
                button.BorderBrush = null;
                button.Foreground = System.Windows.Media.Brushes.Red;
                WrapPanelOmaLiike.Children.Add(stackPanel);
            }

        }

        private void SaveDataToJson() //Jsonin tallennus methodi, muuttaa Sarjalistan Jsoniin sopivaksi. jonka jälkeen tallentaa data2 jsoniin.
        {
            string json = JsonConvert.SerializeObject(SarjaListTo, Formatting.Indented);

            string filePath = "dataTo.json";
            File.WriteAllText(filePath, json);

        }

        private void LoadDataFromJson() //Hakee "vanhat" tiedot jsonista. 
        {
            string filePath = "dataTo.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                SarjaListTo = JsonConvert.DeserializeObject<List<Sarja>>(json);
            }
            else
            {
                MessageBox.Show("Data file not found.");
            }
        }
        private void PoistaSarja_Click(object sender, RoutedEventArgs e)
        {        // Treenin  poisto nappi
            Button button = (Button)sender;
            int index = (int)button.Tag;

            // Poista kyseisen "X" -painikkeen yläpuolella olevat tiedot käyttöliittymästä
            WrapPanelOmaLiike.Children.RemoveAt(index);

            // Poista Sarja-objekti SarjaListSu-listasta
            SarjaListTo.RemoveAt(index);

            // Päivitä käyttöliittymä
            Paivittaja();

            // Tallenna muutokset JSON-tiedostoon
            SaveDataToJson();

        }
        private void UpdateUI() //Methodi joka antaa näyttää "vanhat" tiedot jsonista. Jonka ansioista henkilö voi seurata paljonko on tehnyt jo toistoja
        {
            WrapPanelOmaLiike.Children.Clear(); // Clear existing items before adding new ones

            foreach (var sarja in SarjaListTo)
            {
                // Create a TextBlock to display the Sarja data
                TextBlock textBlock = new TextBlock();
                textBlock.Text = $"{sarja.Liike} - {sarja.Pituus} Toistoa - {sarja.Paino} KG";
                textBlock.FontSize = 14;

                // Add the TextBlock to the WrapPanelOmaLiike
                WrapPanelOmaLiike.Children.Add(textBlock);
            }
        }
    }
}
