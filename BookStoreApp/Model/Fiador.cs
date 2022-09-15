using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Model
{
    public class Fiador
    {
        public int Cedula { set; get; }
        public string Nombre { set; get; }
        public double Deuda { set; get; }
        public Fiador(int cedula, string nombre, double deuda)
        {
            Cedula = cedula;
            Nombre = nombre;
            Deuda = deuda;
        }
    }
}
