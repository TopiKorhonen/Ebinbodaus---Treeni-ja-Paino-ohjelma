using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ohjelmisto_projekti
{
    class Sarja
    {
        public string Liike { get; set; }
        public string Pituus { get; set; }
        public string Paino { get; set; }

        public Sarja(string Liike, string Pituus, string Paino)
        {
            this.Liike = Liike;
            this.Pituus = Pituus;
            this.Paino = Paino;
        }
    }
}
