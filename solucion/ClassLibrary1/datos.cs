using MySql.Data.MySqlClient;

namespace solucion.datos
{
    public class Datos
    {
        private string cadenaConexion =
            "Server=localhost;Database=alumnosdb;Uid=root;Pwd=;";


       
        public (int Legajo, string Nombre, string Condicion)? BuscarAlumno(int legajo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"SELECT legajo, nombre, condicion
                                    FROM alumnos
                                    WHERE legajo = @legajo";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@legajo", legajo);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return (
                                Convert.ToInt32(lector["legajo"]),
                                lector["nombre"].ToString(),
                                lector["condicion"].ToString()
                            );
                        }
                    }
                }
            }

            return null;
        }


        
        public bool AgregarAlumno(int legajo, string nombre, string condicion)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"INSERT INTO alumnos
                                    (legajo, nombre, condicion)
                                    VALUES
                                    (@legajo, @nombre, @condicion)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@legajo", legajo);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@condicion", condicion);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }


        // MODIFICAR - UPDATE
        public bool ModificarAlumno(int legajo, string nombre, string condicion)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"UPDATE alumnos
                                    SET nombre = @nombre,
                                        condicion = @condicion
                                    WHERE legajo = @legajo";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@legajo", legajo);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@condicion", condicion);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }


        public bool EliminarAlumno(int legajo)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"DELETE FROM alumnos
                                    WHERE legajo = @legajo";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@legajo", legajo);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }
    }
}
