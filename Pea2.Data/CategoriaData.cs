using Pea.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea2.Data
{
    public class CategoriaData
    {

        string cadenaConexion = "server=localhost; database=Parcial; Integrated Security=true";
        public List<Categoria> Listar()
        {
            var listado = new List<Categoria>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Categoria", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Categoria tipo;
                            while (lector.Read())
                            {
                                tipo = new Categoria();
                                tipo.IdCategoria = int.Parse(lector[0].ToString());
                                tipo.Nombre = lector[1].ToString();
                                listado.Add(tipo);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Categoria BuscarPorId(int id)
        {
            var categoria = new Categoria();
            return categoria;
        }

        public bool Insertar()
        {
            return true;
        }
    }
}
