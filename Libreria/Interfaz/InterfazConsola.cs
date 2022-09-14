using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Interfaz
{
    class InterfazConsola
    {

        public InterfazConsola()
        {
            Menu();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"-----------Menu de Libreria---------");
                Console.WriteLine("1. Dormir");
                Console.Write("Ingrese operacion que desea realizar : ");
                int opcion = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------------");
                Console.WriteLine();

                if (opcion == 1)
                {
                    Console.WriteLine("Monda");
                }
                if (opcion == 2)
                {
                    Console.WriteLine("Monda");
                }
                if (opcion == 3)
                {
                    Console.WriteLine("Monda");
                }
                if (opcion == 4)
                {
                    Console.WriteLine("Monda");
                }
                if (opcion == 5)
                {
                    Console.WriteLine("Monda");
                }
                if (opcion == 6)
                {
                    Console.WriteLine("-------- Salio correctamente --------");
                    break;
                }
                if (opcion < 1 || opcion > 7)
                {
                    
                }

            }

        }

    }
}
