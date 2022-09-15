using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BookStoreApp.Mundo
{
    public class Bookshop
    {
        public List<Book> Libros { get; set; }
        public List<Fiador> Fiadores { get; set; }
        public Carrito Carrito { get; set; }
        
        public Bookshop()
        {
            Libros = new List<Book>();

            Carrito = new Carrito();

            Fiadores = new List<Fiador>();

            Book libro1 = new ("1", "GOT", "Ficción", 20, 5000);

            Book libro2 = new ("2","MONDA", "Porno", 20, 5000);

            Libros.Add(libro1);
            Libros.Add(libro2);

        }   
        //Validamos si la libria cuenta con el libro.
        public bool ValidarLibro(string codigo)
        {

            foreach (Book book in Libros)
            {
                if (book.Code == codigo){
                    return true;
                }
            }

            return false;
        }


        public bool ModificarLibro(string codigo, string nombre, string categoria, int cantidad, double valor)
        {
            foreach (Book book in Libros)
            {
                if (book.Code == codigo)
                {
                    book.Name = nombre;
                    book.Category = categoria;
                    book.Amount = cantidad;
                    book.Value = valor;
                    return true;
                }
            }
            return false;
        }

        public bool AgregarLibro(string codigo, string nombre, string categoria, int cantidad, double valor)
        {
            if (ValidarLibro(codigo))
            {
                return false;
            }
            else
            {
                Book libro = new(codigo, nombre, categoria, cantidad, valor);
                Libros.Add(libro);
                return true; 
            }

        }

        public bool eliminarLibro(string codigo)
        {
            foreach  (Book book in Libros)
            {
                if (book.Code == codigo)
                {
                    Libros.Remove(book);
                    return true;
                }
            }
            return false;
        }

        public string ListarLibros()
        {
            string lista = "";
            foreach (Book item in Libros)
            {
                lista += item.Code + " " + item.Name + " " + item.Category + " " + item.Amount + " " + item.Value + "\n";
            }
            return lista;

        }
        public void VenderLibros()
        {
            foreach (KeyValuePair<string, (int, double)> libro in Carrito.Libro)
            {
                RestarUnidades(libro.Key, libro.Value.Item1);
            }
            Carrito = new Carrito();

        }
        public bool VerificarFiador(int cedula)
        {

            foreach (Fiador fioador in Fiadores)
            {
                if (fioador.Cedula == cedula)
                {
                    return true;
                }
            }

            return false;
        }

        public bool PagarDeudafiador(int cedula, double valor)
        {
            if (VerificarFiador(cedula))
            {
                foreach (Fiador fiador in Fiadores)
                {
                    if (fiador.Cedula == cedula)
                    {
                        fiador.Deuda -= valor;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool AgregarLibroalcarrito(string codigo,  int cantidad)
        {
            if (ValidarLibro(codigo))
            {
                double precio = buscarPrecio(codigo);
                if (precio == 0)
                {
                    return false;
                }
                else
                {
                    (int, double) t = (cantidad, precio);
                    Carrito.Libro.Add(codigo, t);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public double buscarPrecio(string codigo)
        {
            double valor = 0;

            foreach (Book libro in Libros)
            {
                if (libro.Code == codigo)
                {
                    return libro.Value;
                }
            }
            return valor;
        }

        public void RestarUnidades(string codigo, int numeroUnidades)
        {
            foreach (Book libro in Libros)
            {
                if (libro.Code == codigo)
                {
                    libro.SubtractBook(numeroUnidades);
                }
            }
        }
        public void AumentarUnidades(string codigo, int numeroUnidades)
        {
            foreach (Book libro in Libros)
            {
                if (libro.Code == codigo)
                {
                    libro.AddAmount(numeroUnidades);
                }
            }
        }

        public int CantidaddeUnidades(string codigo)
        {
            foreach (Book libro in Libros)
            {
                if (libro.Code == codigo)
                {
                    return libro.Amount;
                }
            }
            return 0;
        }
        public void AgregarFiador(int cedula, string nombre, double deuda = 0 )
        {
            Fiador fiador = new(cedula, nombre, deuda);
            Fiadores.Add(fiador);
        }
        public void Sumardeuda(int cedula,double deuda)
        {
            foreach (Fiador item in Fiadores)
            {
                if (item.Cedula == cedula)
                {
                    item.Deuda += deuda;
                }
            }
        }
        public string ListaFiadores()
        {
            string lista = "";
            foreach (Fiador item in Fiadores)
            {
                lista += item.Cedula + " " + item.Nombre + " " + item.Deuda + "\n";
            }
            return lista;

        }

        public double Buscardeuda(int cedula)
        {
            foreach (Fiador item in Fiadores)
            {
                if (item.Cedula == cedula)
                {
                    return item.Deuda;
                }
            }
            return -1;
        }

        public string UnidadesPoragotarse()
         {
            string lista = "";
            foreach (Book item in Libros)
            {
                if (item.Amount < 5)
                {
                    lista += item.Code + " " + item.Name + " " + item.Category + " " + item.Amount + " " + item.Value + "\n";
                }
            }
            return lista;

        }
    }
}
