using OrderManagement.Models.entities;

namespace OrderManagement.Repository
{
    public interface IOrderRepository
    {
        public Orden GetOrden(int idOrden);

        public IEnumerable<Orden> GetOrdens();

        public bool Update(int idOrden, int idCondicion);

        public bool Insert(Orden orden);

        public bool Delete(int idOrden);
    }   
}