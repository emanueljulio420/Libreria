using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Model
{
    public class Fiador
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public double Debt { set; get; }
        public Fiador(int id, string name, double debt)
        {
            Id = id;
            Name = name;
            Debt = debt;
        }
    }
}
