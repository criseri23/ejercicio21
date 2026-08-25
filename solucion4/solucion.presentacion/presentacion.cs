using System;
using solucion.negocio2;

namespace solucion.presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine(" BÚSQUEDA DE LIBROS");
            Console.WriteLine("=================================");

            Console.Write("Ingrese el ISBN del libro: ");
            string isbn = Console.ReadLine();

            try
            {
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    Console.WriteLine("Error: el ISBN no puede estar vacío.");
                    return;
                }

                LibroDatos datos = new LibroDatos();

                Libro libro = datos.BuscarPorIsbn(isbn);

                if (libro != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Libro encontrado:");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("ISBN: " + libro.Isbn);
                    Console.WriteLine("Título: " + libro.Titulo);
                    Console.WriteLine("Autor: " + libro.Autor);
                    Console.WriteLine("Estado: " +
                        (libro.Disponible ? "Disponible" : "Prestado"));
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No se encontró ningún libro con ese ISBN.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}