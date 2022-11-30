using EmployeeManagement.Models.entities;

namespace EmployeeManagement.Repositories
{
    public interface IEmpleadoRepository
    {
        public Empleado GetEmpleado(int idEmpleado);

        public IEnumerable<Empleado> GetEmpleados();

        public bool Insert(Empleado empleado);

        public bool Delete(int idEmpleado);

        public bool Update(int idEmpleado, Empleado empleado);
    }
}