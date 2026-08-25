using solucion.datos;

namespace solucion.negocios
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }

        public Empleado(int id, string nombre, string puesto, string departamento)
        {
            if (id < 100 || id > 999)
            {
                throw new ArgumentException(
                    "El ID del empleado debe estar entre 100 y 999."
                );
            }

            Id = id;
            Nombre = nombre;
            Puesto = puesto;
            Departamento = departamento;
        }
    }

    public class Negocio
    {
        private Datos datos = new Datos();

        public Empleado BuscarEmpleado(int id)
        {
            if (id < 100 || id > 999)
            {
                throw new ArgumentException(
                    "El ID del empleado debe estar entre 100 y 999."
                );
            }

            EmpleadoDatos empleadoDatos = datos.BuscarEmpleado(id);

            if (empleadoDatos == null)
            {
                return null;
            }

            return new Empleado(
                empleadoDatos.Id,
                empleadoDatos.Nombre,
                empleadoDatos.Puesto,
                empleadoDatos.Departamento
            );
        }
    }
}