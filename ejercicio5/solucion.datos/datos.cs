using MySql.Data.MySqlClient;
using System;

namespace solucion.datos
{
    public class Datos
    {
        private string cadenaConexion =
            "Server=localhost;Database=recursos_humanos;Uid=root;Pwd=;";


     
        public EmpleadoDatos BuscarEmpleado(int id)
        {
            EmpleadoDatos empleado = null;

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"SELECT id, nombre, puesto, departamento
                                    FROM empleados
                                    WHERE id = @id";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            empleado = new EmpleadoDatos
                            {
                                Id = Convert.ToInt32(lector["id"]),
                                Nombre = lector["nombre"].ToString(),
                                Puesto = lector["puesto"].ToString(),
                                Departamento = lector["departamento"].ToString()
                            };
                        }
                    }
                }
            }

            return empleado;
        }


  
        public bool AgregarEmpleado(EmpleadoDatos empleado)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"INSERT INTO empleados
                                    (id, nombre, puesto, departamento)
                                    VALUES
                                    (@id, @nombre, @puesto, @departamento)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", empleado.Id);
                    comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
                    comando.Parameters.AddWithValue("@puesto", empleado.Puesto);
                    comando.Parameters.AddWithValue("@departamento", empleado.Departamento);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }



        public bool ModificarEmpleado(EmpleadoDatos empleado)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"UPDATE empleados
                                    SET nombre = @nombre,
                                        puesto = @puesto,
                                        departamento = @departamento
                                    WHERE id = @id";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", empleado.Id);
                    comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
                    comando.Parameters.AddWithValue("@puesto", empleado.Puesto);
                    comando.Parameters.AddWithValue("@departamento", empleado.Departamento);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }


   
        public bool EliminarEmpleado(int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = @"DELETE FROM empleados
                                    WHERE id = @id";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }
    }


    public class EmpleadoDatos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
    }
}
