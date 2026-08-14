using solucion_datos.datos;

namespace solucion_negocio.negocio
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }

    public class ProductoNegocio
    {
        private ProductoDatos _datos = new ProductoDatos();

        public Producto ObtenerProducto(string codigo)
        {
            // Valida que no esté vacío
            if (string.IsNullOrEmpty(codigo))
                return null;

            // Valida que empiece con PROD-
            if (!codigo.StartsWith("PROD-"))
                return null;

            // Consulta a la capa de Datos
            var resultado = _datos.BuscarPorCodigo(codigo);

            if (resultado == null)
                return null;

            // Transforma los datos en un objeto Producto
            return new Producto
            {
                Codigo = resultado.Value.Codigo,
                Nombre = resultado.Value.Nombre,
                Precio = resultado.Value.Precio
            };
        }
    }
}