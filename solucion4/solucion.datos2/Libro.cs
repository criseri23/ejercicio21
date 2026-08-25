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
        
    }
}
