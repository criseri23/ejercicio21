using solucion.negocio;

Negocio negocio = new Negocio();

Console.WriteLine("CONSULTA DE ALUMNOS");
Console.WriteLine("-------------------");

Console.Write("Ingrese el legajo: ");

if (int.TryParse(Console.ReadLine(), out int legajo))
{
    string mensaje;

    Alumno alumno = negocio.BuscarAlumno(legajo, out mensaje);

    if (alumno != null)
    {
        Console.WriteLine();
        Console.WriteLine("Nombre: " + alumno.Nombre);
        Console.WriteLine("Condición: " + alumno.Condicion);
    }
    else
    {
        Console.WriteLine(mensaje);
    }
}
else
{
    Console.WriteLine("Error: debe ingresar un número.");
}

Console.ReadKey();