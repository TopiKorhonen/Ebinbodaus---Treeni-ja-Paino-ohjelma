using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ohjelmisto_projekti
{
    internal class Painoni
    {
        public int paino { get; set; } // paino grammoina. Nice.
                                       // Käyttäjän empiirisesti deduktoima päätelmä karheusasteesta, eli luokiteltava muuttuja

        private int _paivamaaraa { get; set; }
        public int paivamaaraa
        {
            get
            {
                return _paivamaaraa;
            }
            set
            {
                var tempNumero = value;

                _paivamaaraa = tempNumero;
            }
        } // Käyttäjän arvio kiven laadusta

        public string tunnisteTieto
        {
            get
            {
                return (paino * 3).ToString();
            }
        }

        public Painoni(int paino, int paivamaaraa)
        {

            this.paino = paino;

            this.paivamaaraa = paivamaaraa;
        }
    }
}
