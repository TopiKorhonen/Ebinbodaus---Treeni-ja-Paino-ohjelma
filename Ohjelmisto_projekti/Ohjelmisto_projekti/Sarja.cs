using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ohjelmisto_projekti;

namespace Ohjelmisto_projekti
{
    public static class SarjaStorage
    {
        public static List<Sarja> Sarjat { get; } = new List<Sarja>();

        public static void LisaaSarja(Sarja sarja)
        {
            Sarjat.Add(sarja);
        }

        public static void PoistaSarja(int index)
        {
            Sarjat.RemoveAt(index);
        }
    }

    public class Sarja
    {
        public string Liike { get; set; }
        public string Pituus { get; set; }
        public string Paino { get; set; }

        public Sarja(string liike, string pituus, string paino)
        {
            Liike = liike;
            Pituus = pituus;
            Paino = paino;
        }
    }
}
