

namespace Pea.Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string Observacion { get; set; }
        public int IdCategoria { get; set; }
    }
}
