using StoreManagement.Models.entities;

namespace StoreManagement.Service
{
    public interface IStoreService
    {
        public bool InsertStore(Sucursal sucursal);

        public Sucursal GetSucursal(int idSucursal);

        public IEnumerable<Sucursal> GetSucursals();

        public bool UpdateSucursal(int idSucursal, Sucursal sucursal);

        public bool DeleteSucursal(int idSucursal);
    }
}