using System;
using solucion_negocio.negocio;

public class Program
{
    public static void Main()
    {
        Console.Write("Ingrese el código del producto: ");
        string codigo = Console.ReadLine();

        ProductoNegocio negocio = new ProductoNegocio();

        Producto producto = negocio.ObtenerProducto(codigo);

        if (producto != null)
        {
            Console.WriteLine("Producto encontrado:");
            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Precio: ${producto.Precio}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado o código inválido.");
        }
    }
}