using DetallesOrdenManagement.Models.entities;

namespace DetallesOrdenManagement.Repository
{

    public interface IDetallesOrdenRepository
    {
        public bool Insert(Detallesorden detallesOrden);

        public Detallesorden GetDetallesorden(int idDetallesOrden);

        public IEnumerable<Detallesorden> GetDetallesordens();
        public bool Delete(int idDetallesOrden);
        
    }
}