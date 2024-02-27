using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ohjelmisto_projekti
{
    class PaivaLista
    {
        public DateTime date { get; set; }

        public PaivaLista(DateTime date)
        {

            this.date = date;
        }

        public string tunnisteTieto
        {
            get
            {
                return (10 * (5 + 2) / 2).ToString();
            }
        }
    }
}
