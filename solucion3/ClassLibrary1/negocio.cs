using solucion.datos;

namespace solucion.negocio
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public string Modelo { get; set; }
        public bool TieneDeuda { get; set; }
    }

    public class VehiculoNegocio
    {
        private VehiculoDatos datos = new VehiculoDatos();

        public Vehiculo BuscarVehiculo(string patente)
        {
            if (string.IsNullOrEmpty(patente) || patente.Length < 6)
            {
                return null;
            }

            var resultado = datos.BuscarVehiculo(patente);

            if (resultado == null)
            {
                return null;
            }

            return new Vehiculo
            {
                Patente = patente,
                Modelo = resultado.Value.Modelo,
                TieneDeuda = resultado.Value.TieneDeuda
            };
        }
    }
}