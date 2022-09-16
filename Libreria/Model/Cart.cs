using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Model
{
    public class Cart
    {

        public Dictionary<string, (int, double)> Book { get; set; }

        public Cart()
        {
            Book = new Dictionary<string, (int, double)>();
        }

        /// <summary>
        /// Calculate the total to pay by adding the price of the books found in the dictionary of the shopping cart.
        /// </summary>
        /// <returns>Returns the total to pay.</returns>
        public double CalculateTotal()
        {
            double total = 0;

            foreach (KeyValuePair<string, (int, double)> book in Book)
            {
                total = book.Value.Item2 * book.Value.Item1;
            }
            return total;
        }

    }
}
