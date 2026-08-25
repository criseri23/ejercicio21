using solucion.negocio;

VehiculoNegocio negocio = new VehiculoNegocio();

Console.Write("Ingrese la patente: ");
string patente = Console.ReadLine();

if (string.IsNullOrEmpty(patente) || patente.Length < 6)
{
    Console.WriteLine("Error: la patente debe tener al menos 6 caracteres.");
}
else
{
    Vehiculo vehiculo = negocio.BuscarVehiculo(patente);

    if (vehiculo == null)
    {
        Console.WriteLine("Vehículo no encontrado.");
    }
    else
    {
        Console.WriteLine("Modelo: " + vehiculo.Modelo);

        if (vehiculo.TieneDeuda)
        {
            Console.WriteLine("Tiene deudas pendientes.");
        }
        else
        {
            Console.WriteLine("No tiene deudas pendientes.");
        }
    }
}

Console.ReadKey();