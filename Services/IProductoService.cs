using pizzitas_web.Models.entities;

namespace pizzitas_web.Services
{
    public interface IProductoService
    {
        public Producto GetProducto(int idProducto);

        public IEnumerable<Producto> GetProductos();

        public bool InsertarProducto(Producto producto);

        public bool DeleteProducto(int idProducto);

        public bool UpdateProdcuto(int idProducto, Producto producto);
    }
}