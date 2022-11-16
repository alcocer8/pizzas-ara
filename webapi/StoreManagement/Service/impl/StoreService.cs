using StoreManagement.Models.entities;
using StoreManagement.Repository;

namespace StoreManagement.Service.impl
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            this._storeRepository = storeRepository;
        }

        public bool InsertStore(Sucursal sucursal)
        {
            return this._storeRepository.Insert(sucursal);
        }

        public Sucursal GetSucursal(int idSucursal)
        {
            return this._storeRepository.GetSucursal(idSucursal);
        }

        public IEnumerable<Sucursal> GetSucursals()
        {
            return this._storeRepository.GetSucursals();
        }

        public bool UpdateSucursal(int idSucursal, Sucursal sucursal)
        {
            return this._storeRepository.Update(idSucursal, sucursal);
        }

        public bool DeleteSucursal(int idSucursal)
        {
            return this._storeRepository.Delete(idSucursal);
        }
    }
}