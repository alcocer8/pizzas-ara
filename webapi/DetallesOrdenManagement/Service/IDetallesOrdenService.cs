using DetallesOrdenManagement.Models.entities;

namespace DetallesOrdenManagement.Service
{
    public interface IDetallesOrdenService
    {
        public bool InsertDetallesOrden(Detallesorden detallesorden);

        public Detallesorden GetDetallesorden(int idDetallesOrden);

        public IEnumerable<Detallesorden> GetDetallesordens();

        public bool DeleteDetallesOrden(int idDetallesOrden);
    }
}