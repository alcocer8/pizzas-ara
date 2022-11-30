using StoreManagement.Models.entities;

namespace ProductManagement.Service
{
    public interface IProductoService
    {
        public bool InsertarProducto(Producto producto);
        public Producto GetProducto(int idProducto);

        public IEnumerable<Producto> GetProductos();

        public bool DeleteProducto(int idProducto);

        public bool UpdateProdcuto(int idProducto, Producto producto);
    }
}