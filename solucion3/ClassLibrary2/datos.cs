using MySql.Data.MySqlClient;

namespace solucion.datos
{
    public class VehiculoDatos
    {
        private string cadenaConexion =
            "Server=localhost;Database=vehiculosdb;Uid=root;Pwd=;";


       
        public (string Modelo, bool TieneDeuda)? BuscarVehiculo(string patente)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"SELECT modelo, tiene_deuda
                                    FROM vehiculos
                                    WHERE patente = @patente";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@patente", patente);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return (
                                lector["modelo"].ToString(),
                                Convert.ToBoolean(lector["tiene_deuda"])
                            );
                        }
                    }
                }
            }

            return null;
        }


        
        public bool AgregarVehiculo(string patente, string modelo, bool tieneDeuda)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"INSERT INTO vehiculos
                                    (patente, modelo, tiene_deuda)
                                    VALUES
                                    (@patente, @modelo, @tiene_deuda)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@patente", patente);
                    comando.Parameters.AddWithValue("@modelo", modelo);
                    comando.Parameters.AddWithValue("@tiene_deuda", tieneDeuda);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }


       
        public bool ModificarVehiculo(string patente, string modelo, bool tieneDeuda)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"UPDATE vehiculos
                                    SET modelo = @modelo,
                                        tiene_deuda = @tiene_deuda
                                    WHERE patente = @patente";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@patente", patente);
                    comando.Parameters.AddWithValue("@modelo", modelo);
                    comando.Parameters.AddWithValue("@tiene_deuda", tieneDeuda);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }


       
        public bool EliminarVehiculo(string patente)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"DELETE FROM vehiculos
                                    WHERE patente = @patente";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@patente", patente);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }
    }
}
