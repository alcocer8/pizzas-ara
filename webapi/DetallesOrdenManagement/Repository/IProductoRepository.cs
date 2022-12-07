using DetallesOrdenManagement.Models.entities;

namespace DetallesOrdenManagement.Repository{
    public interface IProductoRepository{
        public IEnumerable<Producto> GetProductosAll();
    }
}