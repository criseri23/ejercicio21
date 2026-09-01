using MySql.Data.MySqlClient;

namespace solucion.datos2
{
    public class LibroDatos
    {
        private string cadenaConexion =
            "Server=localhost;Database=biblioteca;Uid=root;Pwd=;";


     
        public Libro BuscarPorIsbn(string isbn)
        {
            Libro libro = null;

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"SELECT isbn, titulo, autor, disponible
                                    FROM libros
                                    WHERE isbn = @isbn";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@isbn", isbn);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            libro = new Libro(
                                lector["isbn"].ToString(),
                                lector["titulo"].ToString(),
                                lector["autor"].ToString(),
                                Convert.ToBoolean(lector["disponible"])
                            );
                        }
                    }
                }
            }

            return libro;
        }


        public bool AgregarLibro(Libro libro)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"INSERT INTO libros
                                    (isbn, titulo, autor, disponible)
                                    VALUES
                                    (@isbn, @titulo, @autor, @disponible)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@isbn", libro.Isbn);
                    comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                    comando.Parameters.AddWithValue("@autor", libro.Autor);
                    comando.Parameters.AddWithValue("@disponible", libro.Disponible);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }


        public bool ModificarLibro(Libro libro)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"UPDATE libros
                                    SET titulo = @titulo,
                                        autor = @autor,
                                        disponible = @disponible
                                    WHERE isbn = @isbn";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@isbn", libro.Isbn);
                    comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                    comando.Parameters.AddWithValue("@autor", libro.Autor);
                    comando.Parameters.AddWithValue("@disponible", libro.Disponible);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }


        public bool EliminarLibro(string isbn)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"DELETE FROM libros
                                    WHERE isbn = @isbn";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@isbn", isbn);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }
    }
}
