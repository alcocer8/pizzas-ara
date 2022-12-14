using ClientManagement.Models.entities;

namespace ClientManagement.Service
{
    public interface IClienteService
    {
        public Cliente Authenticate(string username, string password);
        public bool InsertClient(Cliente cliente);

        public Cliente GetCliente(int idCliente);

        public IEnumerable<Cliente> GetClientes();

        public bool UpdateCliente(int idCliente, Cliente cliente);

        public bool DeleteCliente(int idCliente);
    }
}