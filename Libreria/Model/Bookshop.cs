using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BookStoreApp.Model
{
    public class Bookshop
    {
        public List<Book> Books { get; set; }
        public List<Fiador> Fiadores { get; set; }
        public Cart cart { get; set; }
        
        public Bookshop()
        {
            Books = new List<Book>();

            cart = new Cart();

            Fiadores = new List<Fiador>();

            Book libro1 = new ("1", "GOT", "Ficción", 20, 5000);

            Book libro2 = new ("2","House of the dragon", "Ficción", 20, 5000);

            Books.Add(libro1);
            Books.Add(libro2);

        }

        //Validamos si la libria cuenta con el libro.
        /// <summary>
        /// Verifies that the book is in the library (the book is searched using the code as a parameter)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>If the book is in the library we return true otherwise false</returns>
        public bool ValidateBook(string code)
        {

            foreach (Book book in Books)
            {
                if (book.Code == code){
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Allows you to change the name, category and value of the book. (the book is searched by code)
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="amount"></param>
        /// <param name="value"></param>
        /// <returns>If the book is found, its attributes to be modified are changed and we return true, otherwise we return false.</returns>
        public bool ModifyBook(string code, string name, string category, int amount, double value)
        {
            foreach (Book book in Books)
            {
                if (book.Code == code)
                {
                    book.Name = name;
                    book.Category = category;
                    book.Amount = amount;
                    book.Value = value;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Allows you to add a new book to the library
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="amount"></param>
        /// <param name="value"></param>
        /// <returns>If the book does not exist: it is added to the library and we return true.
        ///If the book exists in the library: it is not added to the library and we return false</returns>
        public bool AddBook(string code, string name, string category, int amount, double value)
        {
            if (ValidateBook(code))
            {
                return false;
            }
            else
            {
                Book book = new(code, name, category, amount, value);
                Books.Add(book);
                return true; 
            }

        }

        public bool DeleteBook(string code)
        {
            foreach  (Book book in Books)
            {
                if (book.Code == code)
                {
                    Books.Remove(book);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// It shows in the interface the books in a list, with the code, name, category, units, and value.
        /// </summary>
        /// <returns>Returns a string with the books that exist in the library.</returns>
        public string ListBooks()
        {
            string lista = "";
            foreach (Book item in Books)
            {
                lista += item.Code + " " + item.Name + " " + item.Category + " " + item.Amount + " " + item.Value + "\n";
            }
            return lista;

        }

        /// <summary>
        /// A book is added to the shopping cart
        /// </summary>
        /// <param name="code"></param>
        /// <param name="amount"></param>
        /// <returns>If the value of the book is equal to 0, the book is not added to the cart and false is returned, otherwise the book is added and true is returned.</returns>
        public bool AddBooksToCart(string code, int amount)
        {
            if (ValidateBook(code))
            {
                double price = buscarPrecio(code);
                if (price == 0)
                {
                    return false;
                }
                else
                {
                    (int, double) t = (amount, price);
                    cart.Book.Add(code, t);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// The books in the cart are sold and the units sold are subtracted.
        /// </summary>
        public void SellBooks()
        {
            foreach (KeyValuePair<string, (int, double)> book in cart.Book)
            {
                SubtractUnits(book.Key, book.Value.Item1);
            }
            cart = new Cart();

        }

        /// <summary>
        /// Allows you to add a guarantor to the system (if a client cannot pay the total, they can be added as a guarantor).
        /// </summary>
        /// <param name="id">DNI</param>
        /// <param name="name"></param>
        /// <param name="debt">deuda</param>
        public void AddBondsman(int id, string name, double debt = 0) //agregar fiador.
        {
            Fiador bondsman = new(id, name, debt);
            Fiadores.Add(bondsman);
        }

        /// <summary>
        /// It is verified if the guarantor is in the system.
        /// </summary>
        /// <param name="id">DNI</param>
        /// <returns>If the guarantor is in the system, true is returned, otherwise false is returned.</returns>
        public bool CheckBondsman(int id) //Verificar fiador
        {
            foreach (Fiador bondsman in Fiadores)
            {
                if (bondsman.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Pay off a bondsman's debt
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>The value provided by the guarantor is subtracted and true is returned, if the id is not found, false is returned.</returns>
        public bool PayDebt(int id, double value) //pagar deuda.
        {
            if (CheckBondsman(id))
            {
                foreach (Fiador bondsman in Fiadores)
                {
                    if (bondsman.Id == id)
                    {
                        bondsman.Debt -= value;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Save the fasteners in a list of strings
        /// </summary>
        /// <returns>A list of strings with the guarantors is returned.</returns>
        public string ListBondsman()//Listar fiadores.
        {
            string lista = "";
            foreach (Fiador item in Fiadores)
            {
                lista += item.Id + " " + item.Name + " " + item.Debt + "\n";
            }
            return lista;
        }

        public double buscarPrecio(string codigo)
        {
            double valor = 0;

            foreach (Book libro in Books)
            {
                if (libro.Code == codigo)
                {
                    return libro.Value;
                }
            }
            return valor;
        }

        public void SubtractUnits(string code, int numUnits) //Restar unidades de un libro.
        {
            foreach (Book book in Books)
            {
                if (book.Code == code)
                {
                    book.SubtractBook(numUnits);
                }
            }
        }
        public void IncreaseUnits(string code, int numUnits) //Aumentar unidades de un libro.
        {
            foreach (Book book in Books)
            {
                if (book.Code == code)
                {
                    book.AddAmount(numUnits);
                }
            }
        }

        /// <summary>
        /// Check the number of units in a book.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>The number of units in the book is returned.</returns>
        public int QuantityUnits(string code) //cantidad de unidades.
        {
            foreach (Book book in Books)
            {
                if (book.Code == code)
                {
                    return book.Amount;
                }
            }
            return 0;
        }

        /// <summary>
        /// Increases the debt of a guarantor if he wishes.
        /// </summary>
        /// <param name="id">DNI</param>
        /// <param name="debt">Deuda</param>
        public void AddDebt(int id,double debt) //sumar deuda.
        {
            foreach (Fiador item in Fiadores)
            {
                if (item.Id == id)
                {
                    item.Debt += debt;
                }
            }
        }

        /// <summary>
        /// Search for the debt of a guarantor (the guarantor is searched for by the id/cedula).
        /// </summary>
        /// <param name="id">DNI</param>
        /// <returns>Return -1 if the debt is not found, otherwise return the debt.</returns>
        public double SearchDebt(int id) //Buscar deuda
        {
            foreach (Fiador item in Fiadores)
            {
                if (item.Id == id)
                {
                    return item.Debt;
                }
            }
            return -1;
        }

        /// <summary>
        /// Show a list of all the books which have in the inventory a smaller quantity as indicated by the bookstore showing the code of the book and the number of units.
        /// </summary>
        /// <returns>Returns a string in the form of a list with the books about to run out.</returns>
        public string UnitsToRunOut() //Unidades por agotar
         {
            string list = "";
            foreach (Book item in Books)
            {
                if (item.Amount < 5)
                {
                    list += item.Code + " " + item.Name + " " + item.Category + " " + item.Amount + " " + item.Value + "\n";
                }
            }
            return list;

        }
    }
}
