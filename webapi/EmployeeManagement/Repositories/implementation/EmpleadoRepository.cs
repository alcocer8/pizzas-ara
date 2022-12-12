using EmployeeManagement.Models.entities;

namespace EmployeeManagement.Repositories.implementation
{
    public class EmpleadoRepository : IEmpleadoRepository
    {

        private readonly PizzitasContext _context;
        public EmpleadoRepository(PizzitasContext context)
        {
            this._context = context;
        }

        public Empleado GetEmpleado(int idEmpleado)
        {
            var result = this._context.Empleados.FirstOrDefault(e => e.Idempleado == idEmpleado)!;

            if(result == null)
                return new Empleado();

            return result;
        }

        public IEnumerable<Empleado> GetEmpleados()
        {
            return this._context.Empleados;
        }


        public bool Insert(Empleado empleado)
        {
            var transation = _context.Database.BeginTransaction();
            try
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                transation.Commit();
                return true;
            }
            catch (System.Exception)
            {
                transation.Rollback();
                throw;
                
            }
        }

        public bool Update(int idEmpleado, Empleado empleado)
        {
            var tmpEmpleado = this._context.Empleados.FirstOrDefault(p => p.Idempleado == idEmpleado);

            if(tmpEmpleado == null)
                return false;

            tmpEmpleado.Name = empleado.Name;
            tmpEmpleado.Lastname = empleado.Lastname;
            tmpEmpleado.Celular = empleado.Celular;
            tmpEmpleado.Idcargo = empleado.Idcargo;
            tmpEmpleado.Pass = empleado.Pass;

            this._context.Empleados.Update(tmpEmpleado);
            this._context.SaveChanges();
            return true;
        }

        public bool Delete(int idEmpleado)
        {
            var result = this._context.Empleados.FirstOrDefault(emp => emp.Idempleado == idEmpleado);

            if(result == null)
                return false;

            this._context.Empleados.Remove(result);
            this._context.SaveChanges();
            return true;
        }
    }
}