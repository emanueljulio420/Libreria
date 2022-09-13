using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Dominio
{
    public class Libreria
    {
        public List<Book> Libros { get; set; }
        
        public Libreria()
        {
            Libros = new List<Book>();

            Book libro1 = new Book();
            libro1.Codigo = "01";
            libro1.Nombre = "GOT";
            libro1.Categoria = "Ficción";
            libro1.Cantidad = 20;
            libro1.Valor = 5000;

            Book libro2 = new Book();
            libro2.Codigo = "01";
            libro2.Nombre = "GOT";
            libro2.Categoria = "Ficción";
            libro2.Cantidad = 20;
            libro2.Valor = 5000;

            Libros.Add(libro1);
            Libros.Add(libro2);

        }
        
        //Validamos si la libria cuenta con el libro.
        public int ValidarLibro(string codigo)
        {
            int encontro = -1;
            for (int i = 0; i < Libros.Count; i++)
            {
                if (Libros[i].Codigo == codigo)
                {
                    encontro = i;
                }
            }
            return encontro; //retorna la posicion del libro en la lista.
        }

        public bool ModificarLibro(string codigo, string nombre, string categoria, double valor)
        {
            int enc = this.ValidarLibro(codigo); //si el libro existe retorna la posicion

            if (enc >= 0)
            {
                Libros[enc].cambiarNombre(nombre);
                Libros[enc].cambiarCategoria(categoria);
                Libros[enc].cambiarValor(valor);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Se agrega el libro a lista de libros, si el libro existe se suma la cantidad, si no existe se agrega como libro nuevo.
        /// </summary>
        /// <param name="libro"></param>
        /// <returns>bool value</returns>
        public bool AgregarLibro(Book libro)
        {
            int enc = ValidarLibro(libro.Codigo);
            if (enc >= 0)
            {
                Libros[enc].sumarCantidad(libro.Cantidad); //si el libro existe se suma a la cantidad
            }
            else
            {
                Libros.Add(libro); //si no existe, se agrega el libro
            }

            return true;
        }

        //Elimina un libro de la maquina.
        public bool eliminarLibro(string codigo)
        {
            int enc = ValidarLibro(codigo);

            if (enc >= 0)
            {
                Libros.RemoveAt(enc);
                return true;
            }

            return false;
        }

        //Listamos los libros.
        public string listarLibros()
        {
            string lista = "";
            foreach (Book item in Libros)
            {
                lista += item.Codigo + " " + item.Nombre + " " + item.Categoria + " " + item.Cantidad + " " + item.Valor + "\n";
            }
            return lista;

        }

    }
}
