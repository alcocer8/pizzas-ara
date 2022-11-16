using ClientManagement.Models.entities;

namespace ClientManagement.Repository.impl
{
    public class ClientRepository : IClientRepository
    {

        private readonly PizzitasContext _context;
        public ClientRepository(PizzitasContext context)
        {
            this._context = context;
        }

        public bool Insert(Cliente cliente)
        {
            var transation = _context.Database.BeginTransaction();
            try
            {
                this._context.Clientes.Add(cliente);
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

        public Cliente GetCliente(int idCliente)
        {
            var result = this._context.Clientes.FirstOrDefault(c => c.Idcliente == idCliente);

            if(result == null) return new Cliente();

            return result;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return this._context.Clientes;
        }

        public bool Update(int idCliente, Cliente cliente)
        {
            var result = this._context.Clientes.FirstOrDefault(c => c.Idcliente == idCliente);

            if(result == null) return false;

            result.Name = cliente.Name;
            result.Lastname = cliente.Lastname;
            result.Phone = cliente.Phone;
            result.Calle = cliente.Calle;
            result.Colonia = cliente.Colonia;
            result.Ninterior = cliente.Ninterior;
            result.Cp = cliente.Cp;
            result.Referencias = cliente.Referencias;
            result.Idmunicipio = cliente.Idmunicipio;
            result.Idciudad = cliente.Idciudad;
            result.Idestado = cliente.Idestado;

            this._context.Clientes.Update(result);
            this._context.SaveChanges();

            return true;
        }

        public bool Delete(int idCliente)
        {
            var result = this._context.Clientes.FirstOrDefault(c => c.Idcliente == idCliente);

            if(result == null)
                return false;

            this._context.Clientes.Remove(result);

            this._context.SaveChanges();
            return true;
        }
    }
}