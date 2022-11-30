using EmployeeManagement.Models.entities;

namespace EmployeeManagement.Repositories.implementation
{
    public class CargoRepository : ICargoRepository
    {
        private readonly PizzitasContext _context;
        public CargoRepository(PizzitasContext context)
        {
            this._context = context;
        }

        public IEnumerable<Cargo> GetCargos()
        {
            return this._context.Cargos;
        }
    }
}