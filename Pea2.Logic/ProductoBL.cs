using Pea.Dominio;
using Pea2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pea2.Logic
{
    public class ProductoBL
    {
        public static List<Producto> Listar()
        {
            var productoData = new ProductoData();
            return productoData.Listar();
        }

        public static Producto BuscarPorId(int id)
        {
            var productoData = new ProductoData();
            return productoData.BuscarPorId(id);
        }

        public static bool Insertar(Producto Producto)
        {
            var ProductoData = new ProductoData();
            return ProductoData.Insertar(Producto);
        }

        public static bool Actualizar(Producto Producto)
        {
            var ProductoData = new ProductoData();
            return ProductoData.Actualizar(Producto);
        }

        public static bool Eliminar(int id)
        {
            var ProductoData = new ProductoData();
            return ProductoData.Eliminar(id);




        }
        
    
          }
}   

