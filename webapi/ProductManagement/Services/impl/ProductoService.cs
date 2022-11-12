using pizzitas_web.Models.entities;
using pizzitas_web.Repositories;

namespace pizzitas_web.Services.impl
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            this._productoRepository = productoRepository;
        }

        public Producto GetProducto(int idProducto)
        {
            return this._productoRepository.GetProducto(idProducto);
        }

        public IEnumerable<Producto> GetProductos()
        {
            return this._productoRepository.GetProductos();
        }

        public bool InsertarProducto(Producto producto)
        {
            return this._productoRepository.Insert(producto);
        }

        public bool DeleteProducto(int idProducto)
        {
            return this._productoRepository.Delete(idProducto);
        }

        public bool UpdateProdcuto(int idProducto, Producto producto)
        {
            return this._productoRepository.Update(idProducto, producto);
        }
    }
}