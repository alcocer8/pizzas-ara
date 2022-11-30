using System;
using EmployeeManagement.Models.entities;


namespace EmployeeManagement.Services
{
    public interface IEmpleadoService
    {
        public Empleado Authenticate (string username, string password);
        
        public string CalculateHash(string plaintText);
        public Empleado GetEmpleado(int idEmpleado);

        public IEnumerable<Empleado> GetEmpleados();

        public bool InsertarEmpleado(Empleado empleado);

        public bool DeleteEmpleado(int idEmpleado);

        public bool UpdateEmpleado(int idEmpleado, Empleado empleado);
    }
}