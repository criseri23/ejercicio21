using System.Collections.Generic;
using System.Linq;

namespace Solucion_datos.datos
{
    public class ProductoDatos
    {
 
        private List<(string Codigo, string Nombre, decimal Precio)> _tablaProductos =
            new List<(string, string, decimal)>
        {
            ("PROD-101", "Teclado", 25000),
            ("PROD-102", "Mouse", 15000),
            ("PROD-103", "Monitor", 180000)
        };

        public (string Codigo, string Nombre, decimal Precio)? BuscarPorCodigo(string codigo)
        {
            var resultado = _tablaProductos.FirstOrDefault(p => p.Codigo == codigo);

            if (resultado.Codigo == null)
                return null;

            return resultado;
        }
    }
}
