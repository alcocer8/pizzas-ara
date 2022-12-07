using DetallesOrdenManagement.Models.entities;

namespace DetallesOrdenManagement.Repository.impl
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly PizzitasContext _context;

        public ProductoRepository(PizzitasContext context)
        {
            this._context = context;
        }

        public IEnumerable<Producto> GetProductosAll(){
            return this._context.Productos;
        }
    }
}