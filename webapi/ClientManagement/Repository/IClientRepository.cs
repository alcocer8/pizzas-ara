using ClientManagement.Models.entities;

namespace ClientManagement.Repository
{
    public interface IClientRepository
    {
        public bool Insert(Cliente cliente);

        public Cliente GetCliente(int idCliente);

        public IEnumerable<Cliente> GetClientes();

        public bool Update(int idCliente, Cliente cliente);

        public bool Delete(int idCliente);
    }
}