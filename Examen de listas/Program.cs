using System;

namespace Examen_de_lista
{
  


    class Pragram
    {

        static List<string> Productos = new List<string>();
        static List<double> Precio = new List<double>();

        static void Main(string[] args)
        {
            static void MostrarOpciones()
            {
                Console.WriteLine("====Lista de Opciones del Inventario");
                Console.WriteLine();
                Console.WriteLine("Opcion 1: Agregar un productos");
                Console.WriteLine("Opcion 2: Mostrar todos los productos");
                Console.WriteLine("Opcion 3: Buscar un producto");
                Console.WriteLine("Opcion 4: Modificar un producto");
                Console.WriteLine("Opcion 5: Eliminar un producto");
                Console.WriteLine("Opcion 6: Mostrar estadistica");
                Console.WriteLine("Opcion 7: Ordenar la lista");
                Console.WriteLine("Opcion 8: Salir");
            }

            static void Mostarproducto()
            {
                

                if(Productos.Count == -1 || Precio.Count == -1)
                {
                    Console.WriteLine();
                    Console.WriteLine("NO se encuentran productos en el inventario");
                    Console.WriteLine();
                }

                for(int i = 0; i <= Productos.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Producto: {Productos[i]} Precio: ${Precio[i]}");
                    Console.WriteLine();
                }
            }



        }

  




    }







}