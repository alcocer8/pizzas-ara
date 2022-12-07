using DetallesOrdenManagement.Models.entities;

namespace DetallesOrdenManagement.Repository.impl
{
    public class DetallesOrdenRepository : IDetallesOrdenRepository
    {
        private readonly PizzitasContext _context;
        public DetallesOrdenRepository(PizzitasContext pizzitasContext)
        {
            this._context = pizzitasContext;
        }

        public bool Insert(Detallesorden detallesOrden)
        {
            var transation = _context.Database.BeginTransaction();
            try
            {
                this._context.Detallesordens.Add(detallesOrden);
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

        public Detallesorden GetDetallesorden(int idDetallesOrden)
        {
            var result = this._context.Detallesordens.FirstOrDefault(d => d.Iddetalles == idDetallesOrden);

            if(result == null) return new Detallesorden();

            return result;
        }

        public IEnumerable<Detallesorden> GetDetallesordens()
        {
            return this._context.Detallesordens;
        }


        public bool Delete(int idDetallesOrden)
        {
            var result = this._context.Detallesordens.FirstOrDefault(d => d.Iddetalles == idDetallesOrden);

            if(result == null)
                return false;

            this._context.Detallesordens.Remove(result);

            this._context.SaveChanges();
            return true;
        }

        public dynamic OrdenDellado()
        {
            var ordenes = from Do in this._context.Detallesordens
            join o in this._context.Ordens on Do.Idorden equals o.Idorden
            join c in this._context.Clientes on o.Idcliente equals c.Idcliente
            join p in this._context.Productos on Do.Idproducto equals p.Idproducto  
            select new
            {
                idOrden = o.Idorden,
                fullName = c.Name + " " + c.Lastname,
                //dir = $"Colonia {c.Colonia} Calle: {c.Calle} Numero: {c.Nexterior} ",
                producto = p.Name,
                cantidad = Do.Quantity,
                fecha = o.Fecha 
            };
            return ordenes;
        }
        
    }
}