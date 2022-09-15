using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Mundo
{
    public class Carrito
    {

        public Dictionary<string, (int, double)> Libro { get; set; }

        public Carrito()
        {
            Libro = new Dictionary<string, (int, double)>();
        }

        public double CalcularTotal()
        {
            double total = 0;

            foreach (KeyValuePair<string, (int, double)> libro in Libro)
            {
                total = libro.Value.Item2 * libro.Value.Item1;
            }
            return total;
        }

    }
}
