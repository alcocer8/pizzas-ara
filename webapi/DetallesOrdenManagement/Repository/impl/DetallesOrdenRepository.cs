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
        
    }
}