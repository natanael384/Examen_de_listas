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

            static string AgregarProducto(string pro, double pre)
            {

                if (pro == "")
                {
                    return "El campo no puede estar vacio";
                }

                if (pre <= 0)
                {
                    return "El campo precio debe contener valores positivos.";
                }


                if (Productos.Contains(pro) || Precio.Contains(pre))
                {

                    return "El producto que intentas agregar ya se encuentra en el inventario.";

                }

                Productos.Add(pro);
                Precio.Add(pre);

                return "Se agrego correctamente el producto";

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
                    Console.WriteLine($" {i + 1} Producto: {Productos[i]} Precio: ${Precio[i]}");
                    Console.WriteLine();
                }
            }

            static void BuscarProducto(string Nombre)
            {

                int i = Productos.IndexOf(Nombre);



                if (Nombre == "")
                {
                    Console.WriteLine($"El campo no puede estar vacio");
                }

                if (i == -1)
                {
                    Console.WriteLine($"El producto que intentas Buscar no se encuentra en el inventario");
                }

                if (Productos.Contains(Nombre) == false)
                {

                    Console.WriteLine($"El Producto: {Nombre} es invalido");
                }

                Console.WriteLine();
                Console.WriteLine($"Producto: {Productos[i]} Precio: ${Precio[i]}");
                Console.WriteLine();
            }

  

            static string MosdificarProducto(string actual, string nuevo, double pre)
            {

                int i = Productos.IndexOf(actual);

          

                if (actual == "")
                {
                    return "El campo no puede estar vacio";
                }

                if (i == -1)
                {
                    return "El producto que intentas modificar no se encuentra en el inventario";
                }

                if (nuevo == "")
                {
                    return "El campo no puede estar vacio";
                }

                if (pre <= 0)
                {
                    return "El campo precio debe contener valores positivos.";
                }

                if (Productos.Contains(nuevo) || Precio.Contains(pre))
                {

                    return "El producto que intentas agregar ya se encuentra en el inventario.";

                }

                Productos[i] = nuevo;
                Precio[i] = pre;

                return "Se Modifico correctamente el producto";

            }

            static string EliminarProducto(string Nombre)
            {

                int i = Productos.IndexOf(Nombre);

          

                if (Nombre == "")
                {
                    return "El campo no puede estar vacio";
                }

                if (i == -1)
                {
                    return "El producto que intentas Eliminar no se encuentra en el inventario";
                }

          
                Productos.RemoveAt(i);
                Precio.RemoveAt(i);

                return "Se Modifico correctamente el producto";

            }



            static void MostrarEstadistica()
            {
                int Minimo = 0;
                int Maximo = 0;
                double suma = 0;

                for(int i = 0; i<= Precio.Count; i++)
                {

                    if (Precio[i] > Precio[Maximo]) Maximo = i;
                    if (Precio[i] < Precio[Minimo]) Minimo = i;
                    suma += Precio[i];

                }


                Console.WriteLine();
                Console.WriteLine("===Estadistica===");
                Console.WriteLine();
                Console.WriteLine($"Total de Producto: {Productos.Count}");
                Console.WriteLine($"Producto con Precio Mayor: {Productos[Maximo]} (${Precio[Maximo]})");
                Console.WriteLine($"Producto con Precio Menor: {Productos[Minimo]} (${Precio[Minimo]})");
                Console.WriteLine($"Promedio  de Precios: ${Precio.Average()}");
                Console.WriteLine();

            }

            static void OrdenLista()
            {

                if (Productos.Count == -1 || Precio.Count == -1)
                {
                    Console.WriteLine();
                    Console.WriteLine("NO se encuentran productos en el inventario");
                    Console.WriteLine();
                }

                List<int> index = new List<int>();
                 
                for(int i = 0;i<= Precio.Count; i++)
                {
                    index.Add(i);
                }

                index.Sort((a, b) => Precio[a].CompareTo(Precio[b]));

                foreach(int i in index)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{i + 1} Producto: {Productos[i]} Precio: ${Precio[i]}");
                    Console.WriteLine();
                }
            }



            





        }

  




    }







}