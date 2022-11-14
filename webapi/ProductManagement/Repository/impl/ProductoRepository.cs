using ProductManagement.Models.entities;

namespace ProductManagement.Repository.impl
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly PizzitasContext _context;

        public ProductoRepository(PizzitasContext context)
        {
            this._context = context;
        }


        public bool Insert(Producto producto)
        {
            var transation = _context.Database.BeginTransaction();
            try
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                transation.Commit();
                return true;
            }
            catch (System.Exception)
            {
                transation.Rollback();
                throw;
            }
        }

        public Producto GetProducto(int idProducto)
        {
            var result = this._context.Productos.FirstOrDefault(p => p.Idproducto == idProducto);


            if(result == null)
                return new Producto();

            return result;
        }

        public IEnumerable<Producto> GetProductos()
        {
            return this._context.Productos;
        }

        public bool Update(int idProduct, Producto producto)
        {
            var tmpProduct = this._context.Productos.FirstOrDefault(p => p.Idproducto == idProduct);

            if(tmpProduct == null)
                return false;

            tmpProduct.Name = producto.Name;
            tmpProduct.Descripcion = producto.Descripcion;
            tmpProduct.Precio = producto.Precio;
            tmpProduct.Quantity = producto.Quantity;
            
            
            this._context.Productos.Update(tmpProduct);
            this._context.SaveChanges();
            return true;
        }

        public bool Delete(int idProduct)
        {
            var result = this._context.Productos.FirstOrDefault(p => p.Idproducto == idProduct);

            if(result == null)
                return false;

            this._context.Productos.Remove(result);

            this._context.SaveChanges();
            return true;
        }
    }
}