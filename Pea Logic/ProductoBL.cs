



using Pea.Logic;
using System.Collections.Generic;

namespace Pea.Logic
{
    public static class ProductoBL
    {

        public static List<Producto> Listar()
        {
            var clienteData = new ProductoData();
            return clienteData.Listar();
        }

        public static Cliente BuscarPorId(int id)
        {
            var clienteData = new ClienteData();
            return clienteData.BuscarPorId(id);
        }

        public static bool Insertar(Cliente cliente)
        {
            var clienteData = new ClienteData();
            return clienteData.Insertar(cliente);
        }

        public static bool Actualizar(Cliente cliente)
        {
            var clienteData = new ClienteData();
            return clienteData.Actualizar(cliente);
        }

        public static bool Eliminar(int id)
        {
            var clienteData = new ClienteData();
            return clienteData.Eliminar(id);
        }
}
