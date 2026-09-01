using MySql.Data.MySqlClient;
using System;

namespace Solucion_datos.datos
{
    public class ProductoDatos
    {
        private string cadenaConexion =
            "Server=localhost;Database=productosdb;Uid=root;Pwd=;";

        public (string Codigo, string Nombre, decimal Precio)? BuscarPorCodigo(string codigo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "SELECT Codigo, Nombre, Precio FROM productos WHERE Codigo = @Codigo";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", codigo);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            string codigoProducto = lector["Codigo"].ToString();
                            string nombre = lector["Nombre"].ToString();
                            decimal precio = Convert.ToDecimal(lector["Precio"]);

                            return (codigoProducto, nombre, precio);
                        }
                    }
                }
            }

            return null;
        }


        public bool Agregar(string codigo, string nombre, decimal precio)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta =
                    "INSERT INTO productos (Codigo, Nombre, Precio) " +
                    "VALUES (@Codigo, @Nombre, @Precio)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", codigo);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Precio", precio);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }


     
        public bool Modificar(string codigo, string nombre, decimal precio)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta =
                    "UPDATE productos " +
                    "SET Nombre = @Nombre, Precio = @Precio " +
                    "WHERE Codigo = @Codigo";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", codigo);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Precio", precio);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }


     
        public bool Eliminar(string codigo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta =
                    "DELETE FROM productos WHERE Codigo = @Codigo";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", codigo);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }
    }
}

