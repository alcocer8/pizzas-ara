using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Services
{
    public interface IEmpleadoService
    {
        public Empleado GetEmpleado(int idEmpleado);

        public IEnumerable<Empleado> GetEmpleados();

        public bool InsertarEmpleado(Empleado empleado);

        public bool DeleteEmpleado(int idEmpleado);

        public bool UpdateEmpleado(int idEmpleado, Empleado empleado);
    }
}