using System.Collections.Generic;
using System.Linq;

namespace solucion.datos
{
    public class Datos
    {
        private List<(int Legajo, string Nombre, string Condicion)> alumnos;

        public Datos()
        {
            alumnos = new List<(int, string, string)>
            {
                (10042, "Juan Perez", "Aprobado"),
                (10043, "Maria Gomez", "Regular"),
                (10044, "Lucas Fernandez", "Libre")
            };
        }

        public (int Legajo, string Nombre, string Condicion)? BuscarAlumno(int legajo)
        {
            var alumno = alumnos.FirstOrDefault(a => a.Legajo == legajo);

            if (alumno.Legajo == 0)
            {
                return null;
            }

            return alumno;
        }
    }
}