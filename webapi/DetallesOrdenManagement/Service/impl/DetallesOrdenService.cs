using DetallesOrdenManagement.Models.entities;
using DetallesOrdenManagement.Repository;

namespace DetallesOrdenManagement.Service.impl
{
    public class DetallesOrdenService : IDetallesOrdenService
    {
        private readonly IDetallesOrdenRepository _detallesOrdenRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IOrdenRepository _ordenRepository;

        public DetallesOrdenService(
            IDetallesOrdenRepository detallesOrdenRepository,
            IProductoRepository productoRepository,
            IOrdenRepository ordenRepository
            )
        {
            this._detallesOrdenRepository = detallesOrdenRepository;
            this._productoRepository = productoRepository;
            this._ordenRepository = ordenRepository;
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

        public dynamic OrdenDellado(){
            return this._detallesOrdenRepository.OrdenDellado();
        }
    }
}