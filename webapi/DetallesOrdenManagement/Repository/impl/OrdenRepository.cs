using DetallesOrdenManagement.Models.entities;

namespace DetallesOrdenManagement.Repository.impl
{
    public class OrdenRepository : IOrdenRepository
    {

        private readonly PizzitasContext _context;

        public OrdenRepository(PizzitasContext context)
        {
            this._context = context;
        }

        public IEnumerable<Orden> GetOrdenAll(){
            return this._context.Ordens;
        }
    }
}