namespace solucion.datos
{
    public class VehiculoDatos
    {
        private List<(string Patente, string Modelo, bool TieneDeuda)> vehiculos =
            new List<(string, string, bool)>
            {
                ("AA123CD", "Toyota Corolla", false),
                ("AB456EF", "Ford Focus", true),
                ("AC789GH", "Chevrolet Cruze", false)
            };

        public (string Modelo, bool TieneDeuda)? BuscarVehiculo(string patente)
        {
            foreach (var vehiculo in vehiculos)
            {
                if (vehiculo.Patente == patente)
                {
                    return (vehiculo.Modelo, vehiculo.TieneDeuda);
                }
            }

            return null;
        }
    }
}