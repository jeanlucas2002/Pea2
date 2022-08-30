using Pea.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea2.Data
{
    public class ProductoData
    {
        string cadenaConexion = "server=localhost; Database=Parcial; Integrated Security = true";
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
                                Producto.IdProducto = int.Parse(lector[0].ToString());
                                Producto.Nombre = lector[1].ToString();
                                Producto.Marca = lector[2].ToString();
                                Producto.Precio = double.Parse(lector[3].ToString());
                                Producto.Stock = int.Parse(lector[4].ToString());
                                Producto.Observacion = lector[5].ToString();
                                Producto.IdCategoria = int.Parse(lector[6].ToString());

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
                using (var comando = new SqlCommand("SELECT * FROM Producto WHERE IdProducto = @id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            Producto.IdProducto = int.Parse(lector[0].ToString());
                            Producto.Nombre = lector[1].ToString();
                            Producto.Marca = lector[2].ToString();
                            Producto.Precio = double.Parse(lector[3].ToString());
                            Producto.Stock = int.Parse(lector[4].ToString());
                            Producto.Observacion = lector[5].ToString();
                            Producto.IdCategoria = int.Parse(lector[6].ToString());
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
                var sql = "INSERT INTO Producto(Nombre, Marca, Precio, Stock, Observacion, IdCategoria)"+
                "VALUES(@Nombre, @Marca, @Precio, @Stock, @Observacion, @IdCategoria)";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", Producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", Producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", Producto.Stock);
                    comando.Parameters.AddWithValue("@Observacion", Producto.Observacion);
                    comando.Parameters.AddWithValue("@IdCategoria", Producto.IdCategoria);
                    
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
                var sql = "UPDATE Producto SET Nombre = @Nombre, Marca = @Marca, " +
                    "Precio = @Precio, Stock = @Stock, " +
                    "Observacion = @Observacion, IdCategoria = @IdCategoria, " +

                    "WHERE IdProducto = @IdProducto";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", Producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", Producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", Producto.Stock);
                    comando.Parameters.AddWithValue("@Observacion", Producto.Observacion);
                    comando.Parameters.AddWithValue("@IdCategoria", Producto.IdCategoria);
                    comando.Parameters.AddWithValue("@IdProducto", Producto.IdProducto);
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
                var sql = "DELETE FROM Producto WHERE IdProducto = @IdProducto";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdProducto", id);
                    filasEiminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEiminadas > 0;
        }
    }
}
