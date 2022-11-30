using EmployeeManagement.Models.entities;

namespace EmployeeManagement.Repositories
{
    public interface ICargoRepository
    {
        public IEnumerable<Cargo> GetCargos();
    }
}