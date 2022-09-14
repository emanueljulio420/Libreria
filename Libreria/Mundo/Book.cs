using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Mundo
{
    public class Book
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }

        public Book(string codigo, string nombre, string categoria, int cantidad, double valor)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
            Cantidad = cantidad;
            Valor = valor;
        }

        //suma a la cantidad de un libro.
        public void sumarCantidad(int cantidad)
        {
            Cantidad += cantidad;
        }

        //Cambiamos el nombre de un libro
        public void cambiarNombre(string nombre)
        {
            Nombre = nombre;
        }

        //Cambiamos la categoria de un libro
        public void cambiarCategoria(string categoria)
        {
            Categoria = categoria;
        }

        //Cambiamos el valor de un libro
        public void cambiarValor(double valor)
        {
            Valor = valor;
        }

        //Validamos la cantidad de un libro en la libreria
        public bool validarCantidad()
        {
            if (Cantidad > 0)
            {
                return true;
            }
            return false;
        }

        //Restamos -n a un libro vendido
        public void restarLibro(int cantidad)
        {
            Cantidad -= cantidad;
        }

    }
}
