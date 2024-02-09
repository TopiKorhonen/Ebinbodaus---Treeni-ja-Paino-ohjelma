using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ohjelmisto_projekti
{
    internal class Painoni
    {
        public double paino { get; set; } 

        private int _paivamaaraa { get; set; }
        public int paiva
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
        } 

        public string tunnisteTieto
        {
            get
            {
                return ((paino + paiva) / 2).ToString();
            }
        }

        public Painoni(double paino, int paivamaaraa)
        {

            this.paino = paino;
            this.paiva = paivamaaraa;
        }
    }
}
