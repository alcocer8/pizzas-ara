using DetallesOrdenManagement.Models.entities;
using DetallesOrdenManagement.Repository;

namespace DetallesOrdenManagement.Service.impl
{
    public class DetallesOrdenService : IDetallesOrdenService
    {
        private readonly IDetallesOrdenRepository _detallesOrdenRepository;

        public DetallesOrdenService(IDetallesOrdenRepository detallesOrdenRepository)
        {
            this._detallesOrdenRepository = detallesOrdenRepository;
        }

        public bool InsertDetallesOrden(Detallesorden detallesorden)
        {
             return this._detallesOrdenRepository.Insert(detallesorden);
        }

        public Detallesorden GetDetallesorden(int idDetallesOrden)
        {
            return this._detallesOrdenRepository.GetDetallesorden(idDetallesOrden);
        }

        public IEnumerable<Detallesorden> GetDetallesordens()
        {
            return this._detallesOrdenRepository.GetDetallesordens();
        }

        public bool DeleteDetallesOrden(int idDetallesOrden)
        {
            return this._detallesOrdenRepository.Delete(idDetallesOrden);
        }
    }
}