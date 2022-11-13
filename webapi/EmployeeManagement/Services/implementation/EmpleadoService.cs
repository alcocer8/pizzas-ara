using EmployeeManagement.Models;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.Services.implementation
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            this._empleadoRepository = empleadoRepository;
        }

        public Empleado GetEmpleado(int idEmpleado)
        {
            return this._empleadoRepository.GetEmpleado(idEmpleado);
        }

        public IEnumerable<Empleado> GetEmpleados()
        {
            return this._empleadoRepository.GetEmpleados();
        }

        public bool InsertarEmpleado(Empleado empleado)
        {
            return this._empleadoRepository.Insert(empleado);
        }

        public bool DeleteEmpleado(int idEmpleado)
        {
            return this._empleadoRepository.Delete(idEmpleado);
        }

        public bool UpdateEmpleado(int idEmpleado, Empleado empleado)
        {
            return this._empleadoRepository.Update(idEmpleado, empleado);
        }
    }
}