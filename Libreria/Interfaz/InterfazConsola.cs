using BookStoreApp.Mundo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BookStoreApp.Interfaz
{
    class InterfazConsola
    {
        public Bookshop Libreria { set; get; }
        public InterfazConsola()
        {
            Libreria = new Bookshop();
            Menu();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"-----------Menu de Libreria---------");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Modificar libro");
                Console.WriteLine("3. Eliminar libro");
                Console.WriteLine("4. Validar libro");
                Console.WriteLine("5. Agregar libro al carrito");
                Console.WriteLine("6. Calcular total");
                Console.WriteLine("7. Vender libros");
                Console.WriteLine("8. Mostrar libros en la tienda");
                Console.WriteLine("9. Disminuir cantidad de libros");
                Console.WriteLine("10. Aumentar cantidad de libros");
                Console.WriteLine("11. Verificar cantidad de libros");
                Console.WriteLine("12. Agregar fiador");
                Console.WriteLine("13. Mostrar fiadores");
                Console.WriteLine("14. Pagar deuda");
                Console.WriteLine("15. Unidades a punto de agotarse");
                Console.WriteLine("16. Salir");
                Console.Write("Ingrese operacion que desea realizar : ");
                double opcion = double.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------------");
                Console.WriteLine();

                if (opcion == 1)
                {
                    Console.WriteLine("------------------------------------");
                    Console.Write("Ingrese el codigo del libro: ");
                    string codigo = Console.ReadLine();
                    Console.Write("Ingrese el nombre del libro: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la categoria del libro: ");
                    string categoria = Console.ReadLine();
                    Console.Write("Ingrese la cantidad del libro: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el valor del libro: ");
                    double valor = double.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------------");
                    if (Libreria.AgregarLibro(codigo, nombre, categoria, cantidad, valor)){
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro agregado correctamente ");
                        Console.WriteLine("------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro ya existente");
                        Console.WriteLine("------------------------------------\n");
                    }

                }
                if (opcion == 2)
                {
                    Console.WriteLine("------------------------------------");
                    Console.Write("Ingrese el codigo del libro: ");
                    string codigo = Console.ReadLine();
                    if (Libreria.ValidarLibro(codigo))
                    {
                        Console.Write("Ingrese el nombre del libro: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese la categoria del libro: ");
                        string categoria = Console.ReadLine();
                        Console.Write("Ingrese la cantidad del libro: ");
                        int cantidad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el valor del libro: ");
                        double valor = double.Parse(Console.ReadLine());
                        Console.WriteLine("------------------------------------");
                        if (Libreria.ModificarLibro(codigo, nombre, categoria, cantidad, valor))
                        {
                            Console.WriteLine("\n------------------------------------");
                            Console.WriteLine(" libro cambiado correctamente ");
                            Console.WriteLine("------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro no existente ");
                        Console.WriteLine("------------------------------------");
                    }

                }
                if (opcion == 3)
                {
                    Console.WriteLine("------------------------------------");
                    Console.Write("Ingrese el codigo del libro: ");
                    string codigo = Console.ReadLine();
                    if (Libreria.ValidarLibro(codigo))
                    {
                        if (Libreria.eliminarLibro(codigo))
                        {
                            Console.WriteLine("\n------------------------------------");
                            Console.WriteLine(" libro eliminado correctamente ");
                            Console.WriteLine("------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro no existente ");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (opcion == 4)
                {
                    Console.WriteLine("------------------------------------");
                    Console.Write("Ingrese el codigo del libro: ");
                    string codigo = Console.ReadLine();
                    if (Libreria.ValidarLibro(codigo))
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro existente ");
                        Console.WriteLine("------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro no existente ");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (opcion == 5)
                {
                    Console.WriteLine("------------------------------------");
                    Console.Write("Ingrese el codigo del libro: ");
                    string codigo = Console.ReadLine();
                    Console.Write("Ingrese el numero de unidades: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    if (Libreria.AgregarLibroalcarrito(codigo, cantidad))
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro agregado correctamente");
                        Console.WriteLine("------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro no existente ");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (opcion == 6)
                {
                    double Total = Libreria.Carrito.CalcularTotal();
                    if (Total == 0)
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine($" No hay libros en el carrito ");
                        Console.WriteLine("------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine($" El total es {Total}");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (opcion == 7)
                {
                    double total = Libreria.Carrito.CalcularTotal();
                    Console.WriteLine("\n-------------- Realizar venta ------------------");
                    Console.WriteLine($"Totla a pagar es: {Libreria.Carrito.CalcularTotal()}");
                    Console.Write("Ingrese valor a pagar: ");
                    double pagito = double.Parse(Console.ReadLine());
                    if(pagito >= total)
                    {
                        Console.WriteLine($"Su devuelta es: {pagito - total}");
                    }
                    else
                    {
                        while (pagito <= total)
                        {
                            Console.WriteLine($"le falta: {total - pagito}\n\n");
                            Console.WriteLine($"Desea fiar el excedente : ");
                            Console.WriteLine($"1. Si");
                            Console.WriteLine($"2. No");
                            Console.Write("Ingrese valor a pagar opcion 1 o 2: ");
                            int desicion = int.Parse(Console.ReadLine());
                            if (desicion == 1)
                            {
                                Console.Write("Ingrese la cedula del fiador: ");
                                int cedula = int.Parse(Console.ReadLine());
                                if (Libreria.VerificarFiador(cedula))
                                {
                                    Libreria.Sumardeuda(cedula, total - pagito);
                                    Console.WriteLine("\n------------------------------------");
                                    Console.WriteLine($" Deuda aumentado correctamente ");
                                    Console.WriteLine("------------------------------------");
                                    Libreria.VenderLibros();
                                }
                                else
                                {
                                    Console.Write("Ingrese el nombre dle fiador: ");
                                    string nombre = Console.ReadLine();
                                    Libreria.AgregarFiador(cedula, nombre, total - pagito);
                                    Console.WriteLine("\n------------------------------------");
                                    Console.WriteLine($" Fiador creado correctamente con deuda");
                                    Console.WriteLine("------------------------------------");
                                    Libreria.VenderLibros();
                                    break;
                                }
                            }
                            if (desicion == 2)
                            {
                                Console.Write("Ingrese el aumento del valor a pagar: ");
                                pagito += double.Parse(Console.ReadLine());
                            }
                        }

                    }
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine($" Gracias por comprar en Booker");
                    Console.WriteLine("------------------------------------");
                    Libreria.VenderLibros();
                }
                if (opcion == 8)
                {
                    Console.WriteLine($"{Libreria.ListarLibros()}");
                }
                if (opcion == 9)
                {
                    Console.WriteLine("------------------------------------");
                    Console.Write("Ingrese el codigo del libro: ");
                    string codigo = Console.ReadLine();
                    if (Libreria.ValidarLibro(codigo))
                    {
                        Console.Write("Ingrese de unidades a restar: ");
                        int unidades = int.Parse(Console.ReadLine());
                        Libreria.RestarUnidades(codigo, unidades); 
                    }
                    else
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro no existente ");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (opcion == 10)
                {
                    Console.WriteLine("------------------------------------");
                    Console.Write("Ingrese el codigo del libro: ");
                    string codigo = Console.ReadLine();
                    if (Libreria.ValidarLibro(codigo))
                    {
                        Console.Write("Ingrese de unidades a incrementar: ");
                        int unidades = int.Parse(Console.ReadLine());
                        Libreria.AumentarUnidades(codigo, unidades);
                    }
                    else
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine(" libro no existente ");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (opcion == 11)
                {
                    Console.WriteLine("------------------------------------");
                    Console.Write("Ingrese el codigo del libro: ");
                    string codigo = Console.ReadLine();
                    if (Libreria.ValidarLibro(codigo))
                    {
                        int unidades = Libreria.CantidaddeUnidades(codigo);
                        if (unidades == 0)
                        {
                            Console.WriteLine("\n------------------------------------");
                            Console.WriteLine($" Hay {unidades} disponibles ");
                            Console.WriteLine("------------------------------------");
                        }
                    }
                }
                if (opcion == 12)
                {
                    Console.WriteLine("------------------ Agregar Fiador ------------------");
                    Console.Write("Ingrese la cedula del fiador: ");
                    int cedula = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nombre del fiador: ");
                    string nombre = Console.ReadLine();
                    if (Libreria.VerificarFiador(cedula))
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine($" Fiador ya creado ");
                        Console.WriteLine("------------------------------------");
                    }
                    else
                    {
                        Libreria.AgregarFiador(cedula, nombre);
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine($" Fiador creado correctamente ");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (opcion == 13)
                {
                    Console.WriteLine($"{Libreria.ListaFiadores()}");
                }
                if (opcion == 14)
                {
                    Console.Write("Ingrese la cedula del fiador: ");
                    int cedula = int.Parse(Console.ReadLine());
                    if (Libreria.VerificarFiador(cedula))
                    {
                        double deuda = Libreria.Buscardeuda(cedula);
                        if (deuda == -1)
                        {
                            Console.WriteLine("\n------------------------------------");
                            Console.WriteLine($" Fiador no existe ");
                            Console.WriteLine("------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine($"Deuda total: {deuda}");
                            Console.Write("Ingrese el valor a pagar: ");
                            double pago = double.Parse(Console.ReadLine());
                            Libreria.PagarDeudafiador(cedula, pago);
                            Console.WriteLine("\n------------------------------------");
                            Console.WriteLine($" Pago realizado correctamente ");
                            Console.WriteLine("------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n------------------------------------");
                        Console.WriteLine($" Fiador no existe ");
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (opcion == 15)
                {
                    Console.WriteLine($"{Libreria.UnidadesPoragotarse()}");
                }
                if (opcion == 16)
                {
                    Console.WriteLine("-------- Salio correctamente --------");
                    break;
                }
                if (opcion < 1 || opcion > 17)
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine(" Ingrese un valor valido (pendejo)");
                    Console.WriteLine("------------------------------------");
                }

            }

        }

    }
}
