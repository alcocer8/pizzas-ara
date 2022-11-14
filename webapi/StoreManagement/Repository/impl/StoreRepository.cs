using StoreManagement.Models.entities;
using StoreManagement.Repository;

namespace StoreManagement.Repository.impl
{
    public class StoreRepository : IStoreRepository
    {
        private readonly PizzitasContext _context;

        public StoreRepository(PizzitasContext context)
        {
            this._context = context;
        }

           public bool Insert(Sucursal sucursal)
        {
            var transation = _context.Database.BeginTransaction();
            try
            {
                this._context.Sucursals.Add(sucursal);
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

        public Sucursal GetSucursal(int idSucursal)
        {
            var result = this._context.Sucursals.FirstOrDefault(s => s.Idsucursal == idSucursal);

            if(result == null) return new Sucursal();

            return result;
        }
        public IEnumerable<Sucursal> GetSucursals()
        {
            return this._context.Sucursals;
        }

        public bool Update(int idSucursal, Sucursal sucursal)
        {
            var result = this._context.Sucursals.FirstOrDefault(s => s.Idsucursal == idSucursal);

            if(result == null) return false;

            result.Name = sucursal.Name;
            result.Calle = sucursal.Calle;
            result.Colonia = sucursal.Colonia;
            result.Ninterior = sucursal.Ninterior;
            result.Nexterior =sucursal.Nexterior;
            result.Cp = sucursal.Cp;
            result.Idmunicipio = sucursal.Idmunicipio;
            result.Idciudad = sucursal.Idciudad;
            result.Idestado = sucursal.Idestado;

            this._context.Sucursals.Update(result);
            this._context.SaveChanges();

            return true;
        }

        public bool Delete(int idSucursal)
        {
            var result = this._context.Sucursals.FirstOrDefault(s => s.Idsucursal == idSucursal);

            if(result == null) return false;

            this._context.Sucursals.Remove(result);
            this._context.SaveChanges();
            return true;
        }
    }
}