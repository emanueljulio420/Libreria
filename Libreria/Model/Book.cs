using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Model
{
    public class Book
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public double Value { get; set; }

        public Book(string code, string name, string category, int amount, double value)
        {
            Code = code;
            Name = name;
            Category = category;
            Amount = amount;
            Value = value;
        }

        //suma a la cantidad de un libro.
        public void AddAmount(int amount)
        {
            Amount += amount;
        }

        //Cambiamos el nombre de un libro
        public void RenameBook(string name)
        {
            Name = name;
        }

        //Cambiamos la categoria de un libro
        public void ChangeCategory(string category)
        {
            Category = category;
        }

        //Cambiamos el valor de un libro
        public void ChangeValue(double value)
        {
            Value = value;
        }

        //Validamos la cantidad de un libro en la libreria
        public bool ValidateAmount()
        {
            if (Amount > 0)
            {
                return true;
            }
            return false;
        }

        //Restamos -n a un libro vendido
        public void SubtractBook(int amount)
        {
            Amount -= amount;
        }
    }
}
