using pizzitas_web.Models.entities;

namespace pizzitas_web.Repositories
{
    public interface IProductoRepository
    {
        public Producto GetProducto(int idProducto);

        public IEnumerable<Producto> GetProductos();

        public bool Insert(Producto producto);

        public bool Delete(int idProducto);

        public bool Update(int idProducto, Producto producto);
    }
}