using OrderManagement.Models.entities;

namespace OrderManagement.Service
{

    public interface IOrderService
    {

        public bool InsertOrder(Orden orden);

        public bool DeleteOrden(int idOrden);

        public bool UpdateOrden(int idOrden, int idCondicion);

        public Orden GetOrden(int idOrden);

        public IEnumerable<Orden> GetOrdens();

    }

}