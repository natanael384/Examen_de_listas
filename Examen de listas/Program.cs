using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen_de_lista
{
    class Program
    {
        static List<string> Productos = new List<string>();
        static List<double> Precio = new List<double>();

        static void Main(string[] args)
        {
            int opciones = 0;
            string pro;
            double pre;
            string resultado;

            do
            {
                MostrarOpciones();
                Console.WriteLine();
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opciones)) // Indica que si el valor que ingresó el usuario no es numérico le aparecerá el mensaje y no ejecutará lo demás hasta que sea numérico.
                {
                    Console.WriteLine("Por favor, ingresa un número válido.\n");
                    continue;
                }

                Console.WriteLine();

                switch (opciones) // Este switch compara el valor de la opción que elija el usuario y si coincide con los case le mostrará un apartado dependiendo de lo que elija.
                {
                    case 1: // Este case es para ingresar si el usuario elige la opción número 1.
                        Console.Write("Ingresa un producto: ");
                        pro = Console.ReadLine();
                        Console.Write("Ingresa el precio: ");
                        if (double.TryParse(Console.ReadLine(), out pre))
                        {
                            resultado = AgregarProducto(pro, pre);
                            Console.WriteLine(resultado);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido.");
                        }
                        break;

                    case 2: // Este case es para mostrar productos si el usuario elige la opción número 2.
                        MostrarProducto();
                        break;

                    case 3: // Este case es para buscar producto si el usuario elige la opción número 3.
                        Console.Write("Ingresa el nombre del producto a buscar: ");
                        pro = Console.ReadLine();
                        BuscarProducto(pro);
                        break;

                    case 4: // Este case es para modificar si el usuario elige la opción número 4.
                        Console.Write("Ingresa el nombre actual del producto: ");
                        string proac = Console.ReadLine();
                        Console.Write("Ingresa el nuevo nombre del producto: ");
                        pro = Console.ReadLine();
                        Console.Write("Ingresa el nuevo precio: ");
                        if (double.TryParse(Console.ReadLine(), out pre))
                        {
                            resultado = ModificarProducto(proac, pro, pre);
                            Console.WriteLine(resultado);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido.");
                        }
                        break;

                    case 5: // Este case es para eliminar si el usuario elige la opción número 5.
                        Console.Write("Ingresa el producto a eliminar: ");
                        pro = Console.ReadLine();
                        resultado = EliminarProducto(pro);
                        Console.WriteLine(resultado);
                        break;

                    case 6: // Este case es para mostrar estadística si el usuario elige la opción número 6.
                        MostrarEstadistica();
                        break;

                    case 7: // Este case es para ordenar de manera ascendente si el usuario elige la opción número 7.
                        OrdenLista();
                        break;

                    case 8: // Este case es para salir del sistema si el usuario elige la opción número 8.
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default: // Este default es por si el usuario ingresa un número que no corresponde a las opciones que muestra el menú.
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\n-----------------------------------\n");

            } while (opciones != 8);

            Console.WriteLine("Gracias por darle mantenimiento al inventario.");
        }

        static void MostrarOpciones() // Es para mostrar las opciones.
        {
            Console.WriteLine("==== Lista de Opciones del Inventario ====");
            Console.WriteLine("Opción 1: Agregar un producto");
            Console.WriteLine("Opción 2: Mostrar todos los productos");
            Console.WriteLine("Opción 3: Buscar un producto");
            Console.WriteLine("Opción 4: Modificar un producto");
            Console.WriteLine("Opción 5: Eliminar un producto");
            Console.WriteLine("Opción 6: Mostrar estadística");
            Console.WriteLine("Opción 7: Ordenar la lista");
            Console.WriteLine("Opción 8: Salir");
        }

        static string AgregarProducto(string pro, double pre) // Es para agregar productos.
        {
            if (string.IsNullOrWhiteSpace(pro))
            {
                return "El campo no puede estar vacío.";
            }

            if (pre <= 0)
            {
                return "El campo precio debe contener valores positivos.";
            }

            if (Productos.Contains(pro))
            {
                return "El producto que intentas agregar ya se encuentra en el inventario.";
            }

            Productos.Add(pro);
            Precio.Add(pre);

            return "Se agregó correctamente el producto.";
        }

        static void MostrarProducto() // Es para mostrar todos los productos.
        {
            if (Productos.Count == 0)
            {
                Console.WriteLine("No se encuentran productos en el inventario.");
                return;
            }

            for (int i = 0; i < Productos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Producto: {Productos[i]} | Precio: ${Precio[i]}");
            }
        }

        static void BuscarProducto(string nombre) // Es para buscar los productos.
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El campo no puede estar vacío.");
                return;
            }

            int i = Productos.IndexOf(nombre);

            if (i == -1)
            {
                Console.WriteLine("El producto que intentas buscar no se encuentra en el inventario.");
                return;
            }

            Console.WriteLine($"Producto encontrado -> Producto: {Productos[i]} | Precio: ${Precio[i]}");
        }

        static string ModificarProducto(string actual, string nuevo, double pre) // Es para modificar los productos.
        {
            if (string.IsNullOrWhiteSpace(actual) || string.IsNullOrWhiteSpace(nuevo))
            {
                return "Los campos no pueden estar vacíos.";
            }

            int i = Productos.IndexOf(actual);

            if (i == -1)
            {
                return "El producto que intentas modificar no se encuentra en el inventario.";
            }

            if (pre <= 0)
            {
                return "El campo precio debe contener valores positivos.";
            }

            if (Productos.Contains(nuevo) && actual != nuevo)
            {
                return "El nuevo nombre de producto ya existe en el inventario.";
            }

            Productos[i] = nuevo;
            Precio[i] = pre;

            return "Se modificó correctamente el producto.";
        }

        static string EliminarProducto(string nombre) // Es para eliminar los productos.
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return "El campo no puede estar vacío.";
            }

            int i = Productos.IndexOf(nombre);

            if (i == -1)
            {
                return "El producto que intentas eliminar no se encuentra en el inventario.";
            }

            Productos.RemoveAt(i);
            Precio.RemoveAt(i);

            return "Se eliminó correctamente el producto.";
        }

        static void MostrarEstadistica() // Es para mostrar las estadísticas.
        {
            if (Precio.Count == 0)
            {
                Console.WriteLine("No se encuentran productos en el inventario para calcular estadísticas.");
                return;
            }

            int minimo = 0;
            int maximo = 0;

            for (int i = 0; i < Precio.Count; i++)
            {
                if (Precio[i] > Precio[maximo]) maximo = i;
                if (Precio[i] < Precio[minimo]) minimo = i;
            }

            Console.WriteLine();
            Console.WriteLine("=== Estadísticas ===");
            Console.WriteLine($"Total de productos: {Productos.Count}");
            Console.WriteLine($"Producto con precio mayor: {Productos[maximo]} (${Precio[maximo]})");
            Console.WriteLine($"Producto con precio menor: {Productos[minimo]} (${Precio[minimo]})");
            Console.WriteLine($"Promedio de precios: ${Precio.Average():F2}");
            Console.WriteLine();
        }

        static void OrdenLista() // Es para mostrar las listas en orden.
        {
            if (Productos.Count == 0)
            {
                Console.WriteLine("No se encuentran productos en el inventario.");
                return;
            }

            List<int> index = new List<int>();

            for (int i = 0; i < Productos.Count; i++)
            {
                index.Add(i);
            }

            index.Sort((a, b) => Precio[a].CompareTo(Precio[b]));

            Console.WriteLine("=== Lista Ordenada por Precio ===");
            foreach (int i in index)
            {
                Console.WriteLine($"{i + 1}. Producto: {Productos[i]} | Precio: ${Precio[i]}");
            }
        }
    }
}