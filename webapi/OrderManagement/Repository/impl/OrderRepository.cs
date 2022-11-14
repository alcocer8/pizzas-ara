using OrderManagement.Models.entities;
using OrderManagement.Repository;

namespace OrderManagement.Repository.impl
{
    public class OrdenRepository : IOrderRepository
    {

        private readonly PizzitasContext _context;

        public OrdenRepository(PizzitasContext context)
        {
            this._context =  context;
        }

        public Orden GetOrden(int idOrden)
        {
            var result = this._context.Ordens.FirstOrDefault(o => o.Idorden == idOrden);

            if(result == null) return new Orden();

            return result;
        }

        public IEnumerable<Orden> GetOrdens()
        {
            return this._context.Ordens;
        }

        public bool Update(int idOrden, int idCondicion)
        {
            var result = this._context.Ordens.FirstOrDefault(o => o.Idorden == idOrden);

            if(result == null) return false;

            result.Idcondicion = idCondicion;
            this._context.Ordens.Update(result);
            this._context.SaveChanges();

            return true;
        }

        public bool Insert(Orden orden)
        {
            var transation = _context.Database.BeginTransaction();
            try
            {
                this._context.Ordens.Add(orden);
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

        public bool Delete(int idOrden)
        {
            var result = this._context.Ordens.FirstOrDefault(o => o.Idorden == idOrden);

            if(result == null) return false;

            this._context.Ordens.Remove(result);
            this._context.SaveChanges();
            return true;
        }
    }
}