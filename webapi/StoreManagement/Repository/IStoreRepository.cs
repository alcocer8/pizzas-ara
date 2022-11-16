using StoreManagement.Models.entities;

namespace StoreManagement.Repository
{
    public interface IStoreRepository
    {
        public bool Insert(Sucursal sucursal);

        public Sucursal GetSucursal(int idSucursal);

        public IEnumerable<Sucursal> GetSucursals();

        public bool Update(int idSucursal, Sucursal sucursal);

        public bool Delete(int idSucursal);
    }
}