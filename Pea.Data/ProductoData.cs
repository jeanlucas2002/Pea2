using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pea.Data
{
    internal class ProductoData
    {
       
        
            string cadenaConexion = "server=localhost; Database=Financiera; Integrated Security = true";
            public List<Producto> Listar()
            {
                var listado = new List<Producto>();
                using (var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (var comando = new SqlCommand("Select * From Producto", conexion))
                    {
                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector != null && lector.HasRows)
                            {
                                Producto Producto;
                                while (lector.Read())
                                {
                                    Producto = new Producto();
                                    Producto.ID = int.Parse(lector[0].ToString());
                                    Producto.Nombres = lector[1].ToString();
                                    Producto.Apellidos = lector[2].ToString();
                                    Producto.Direccion = lector[3].ToString();
                                    Producto.Referencia = lector[4].ToString();
                                    Producto.IdTipoProducto = int.Parse(lector[5].ToString());
                                    Producto.IdTipoDocumento = int.Parse(lector[6].ToString());
                                    Producto.NumeroDocumento = lector[7].ToString();

                                    listado.Add(Producto);
                                }
                            }
                        }
                    }
                }
                return listado;
            }

            public Producto BuscarPorId(int id)
            {
                Producto Producto = new Producto();
                using (var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (var comando = new SqlCommand("SELECT * FROM Producto WHERE ID = @id", conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        using (var lector = comando.ExecuteReader())
                        {
                            if (lector != null && lector.HasRows)
                            {
                                lector.Read();
                                Producto = new Producto();
                                Producto.ID = int.Parse(lector[0].ToString());
                                Producto.Nombres = lector[1].ToString();
                                Producto.Apellidos = lector[2].ToString();
                                Producto.Direccion = lector[3].ToString();
                                Producto.Referencia = lector[4].ToString();
                                Producto.IdTipoProducto = int.Parse(lector[5].ToString());
                                Producto.IdTipoDocumento = int.Parse(lector[6].ToString());
                                Producto.NumeroDocumento = lector[7].ToString();
                            }
                        }
                    }
                }
                return Producto;
            }

            public bool Insertar(Producto Producto)
            {
                int filasInsertadas = 0;
                using (var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    var sql = "INSERT INTO Producto (Nombres, Apellidos, " +
                                    "Direccion, Referencia, IdTipoProducto, IdTipoDocumento, " +
                                    "NumeroDocumento, Estado)" +
                                "VALUES(@Nombres, @Apellidos, @Direccion, @Referencia, " +
                                    "@IdTipoProducto, @IdTipoDocumento, @NumeroDocumento, @Estado)";
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombres", Producto.Nombres);
                        comando.Parameters.AddWithValue("@Apellidos", Producto.Apellidos);
                        comando.Parameters.AddWithValue("@Direccion", Producto.Direccion);
                        comando.Parameters.AddWithValue("@Referencia", Producto.Referencia);
                        comando.Parameters.AddWithValue("@IdTipoProducto", Producto.IdTipoProducto);
                        comando.Parameters.AddWithValue("@IdTipoDocumento", Producto.IdTipoDocumento);
                        comando.Parameters.AddWithValue("@NumeroDocumento", Producto.NumeroDocumento);
                        comando.Parameters.AddWithValue("@Estado", Producto.Estado);
                        filasInsertadas = comando.ExecuteNonQuery();
                    }
                }
                return filasInsertadas > 0;
            }

            public bool Actualizar(Producto Producto)
            {
                int filasActualizadas = 0;
                using (var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    var sql = "UPDATE Producto SET Nombres = @Nombres, Apellidos = @Apellidos, " +
                        "Direccion = @Direccion, Referencia = @Referencia, " +
                        "IdTipoProducto = @IdTipoProducto, IdTipoDocumento = @IdTipoDocumento, " +
                        "NumeroDocumento = @NumeroDocumento, Estado = @Estado " +
                        "WHERE ID = @ID";
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombres", Producto.Nombres);
                        comando.Parameters.AddWithValue("@Apellidos", Producto.Apellidos);
                        comando.Parameters.AddWithValue("@Direccion", Producto.Direccion);
                        comando.Parameters.AddWithValue("@Referencia", Producto.Referencia);
                        comando.Parameters.AddWithValue("@IdTipoProducto", Producto.IdTipoProducto);
                        comando.Parameters.AddWithValue("@IdTipoDocumento", Producto.IdTipoDocumento);
                        comando.Parameters.AddWithValue("@NumeroDocumento", Producto.NumeroDocumento);
                        comando.Parameters.AddWithValue("@Estado", Producto.Estado);
                        comando.Parameters.AddWithValue("@ID", Producto.ID);
                        filasActualizadas = comando.ExecuteNonQuery();
                    }
                }
                return filasActualizadas > 0;
            }

            public bool Eliminar(int id)
            {
                int filasEiminadas = 0;
                using (var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    var sql = "DELETE FROM Producto WHERE ID = @id";
                    using (var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        filasEiminadas = comando.ExecuteNonQuery();
                    }
                }
                return filasEiminadas > 0;
            }
        }
    }
}

