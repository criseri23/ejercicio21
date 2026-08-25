using solucion.datos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace solucion.negocio
{
    public class Alumno
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Condicion { get; set; }
    }

    public class Negocio
    {
        private Datos datos = new Datos();

        public Alumno BuscarAlumno(int legajo, out string mensaje)
        {
            // Validación pedida por la consigna
            if (legajo <= 0)
            {
                mensaje = "Error: el legajo debe ser mayor a cero.";
                return null;
            }

            var resultado = datos.BuscarAlumno(legajo);

            if (resultado == null)
            {
                mensaje = "Alumno no encontrado.";
                return null;
            }

            Alumno alumno = new Alumno();

            alumno.Legajo = resultado.Value.Legajo;
            alumno.Nombre = resultado.Value.Nombre;
            alumno.Condicion = resultado.Value.Condicion;

            mensaje = "Alumno encontrado.";

            return alumno;
        }
    }
}