using ClientManagement.Models.entities;
using ClientManagement.Repository;

namespace ClientManagement.Service.impl
{
    public class ClientService : IClienteService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public bool InsertClient(Cliente cliente)
        {
            return this._clientRepository.Insert(cliente);
        }

        public Cliente GetCliente(int idCliente)
        {
            return this._clientRepository.GetCliente(idCliente);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return this._clientRepository.GetClientes();
        }

        public bool UpdateCliente(int idCliente, Cliente cliente)
        {
            return this._clientRepository.Update(idCliente, cliente);
        }

        public bool DeleteCliente(int idCliente)
        {
            return this._clientRepository.Delete(idCliente);
        }
    }
}
