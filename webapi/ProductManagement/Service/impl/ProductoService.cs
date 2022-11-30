using StoreManagement.Models.entities;
using ProductManagement.Repository;


namespace ProductManagement.Service.impl
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;


        public ProductoService(IProductoRepository productoRepository)
        {
            this._productoRepository = productoRepository;
        }

        public bool InsertarProducto(Producto producto)
        {
            return this._productoRepository.Insert(producto);
        }

        public Producto GetProducto(int idProducto)
        {
            
            return this._productoRepository.GetProducto(idProducto);
        }

        public IEnumerable<Producto> GetProductos()
        {
            return this._productoRepository.GetProductos();
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