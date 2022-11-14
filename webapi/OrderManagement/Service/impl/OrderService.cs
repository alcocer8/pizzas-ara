using OrderManagement.Models.entities;
using OrderManagement.Repository;
using OrderManagement.Service;

namespace OrderManagement.Service.impl
{

    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public bool InsertOrder(Orden orden){
            return this._orderRepository.Insert(orden);
        }

        public bool DeleteOrden(int idOrden)
        {
            return this._orderRepository.Delete(idOrden);
        }

        public bool UpdateOrden(int idOrden, int idCondicion)
        {
            return this._orderRepository.Update(idOrden, idCondicion);
        }

        public Orden GetOrden(int idOrden)
        {
            return this._orderRepository.GetOrden(idOrden);
        }

        public IEnumerable<Orden> GetOrdens()
        {
            return this._orderRepository.GetOrdens();
        }
    }
}