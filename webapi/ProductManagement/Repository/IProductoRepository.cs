using StoreManagement.Models.entities;

namespace ProductManagement.Repository
{
    public interface IProductoRepository
    {
        public bool Insert(Producto producto);

        public Producto GetProducto(int idProducto);

        public IEnumerable<Producto> GetProductos();

        

        public bool Update(int idProducto, Producto producto);

        public bool Delete(int idProducto);
    }
}