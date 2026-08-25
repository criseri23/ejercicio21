using solucion.negocios;

namespace solucion.presentacion
{
    internal class Presentacion
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine(" CONSULTA DE EMPLEADOS");
            Console.WriteLine("=================================");

            Console.Write("Ingrese el ID del empleado: ");
            string entrada = Console.ReadLine();

            try
            {
                int id = int.Parse(entrada);

                Negocio negocio = new Negocio();

                Empleado empleado = negocio.BuscarEmpleado(id);

                if (empleado != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Empleado encontrado:");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("ID: " + empleado.Id);
                    Console.WriteLine("Nombre: " + empleado.Nombre);
                    Console.WriteLine("Puesto: " + empleado.Puesto);
                    Console.WriteLine("Departamento: " + empleado.Departamento);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No se encontró un empleado con ese ID.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: debe ingresar un número válido.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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