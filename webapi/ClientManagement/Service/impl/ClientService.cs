using ClientManagement.Models.entities;
using ClientManagement.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;


namespace ClientManagement.Service.impl
{
    public class ClientService : IClienteService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IConfiguration _configuration;
        public ClientService(IClientRepository clientRepository, IConfiguration configuration)
        {
            this._clientRepository = clientRepository;
            this._configuration = configuration;
        }

        public Cliente Authenticate(string username, string password)
        {
            var cliente = this._clientRepository.GetClientes().SingleOrDefault(e => e.Email == username && e.Pass == this.CalculateHash(password));
            if (cliente == null) return cliente!;


            var tokenHandler = new JwtSecurityTokenHandler();
            var strKey = this._configuration.GetValue<string>("JwtSettings:Key");
            var key = System.Text.Encoding.ASCII.GetBytes(strKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[] {
                        new Claim ("Email", cliente.Email!),
                        new Claim ($"First Name", cliente.Name!),
                        new Claim(ClaimTypes.Role, "Cliente")
                    }
                ),
                Expires = DateTime.Now.AddHours(1),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            cliente.Token = tokenHandler.WriteToken(token);
            cliente.Pass = string.Empty;

            return cliente;
        }

        public string CalculateHash(string plaintText)
        {
            using var sha1 = System.Security.Cryptography.SHA1.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(plaintText);
            var sb = new System.Text.StringBuilder();

            var cipherBytes = sha1.ComputeHash(bytes);
            foreach (var b in cipherBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public bool InsertClient(Cliente cliente)
        {
            string pass = cliente.Pass;
            cliente.Pass = this.CalculateHash(pass);
            return this._clientRepository.Insert(cliente);
        }

        public Cliente GetCliente(int idCliente)
        {

            var cliente = this._clientRepository.GetCliente(idCliente);
            cliente.Pass = "";
            cliente.Token = "";
            return cliente;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            
            var clientes = this._clientRepository.GetClientes();
            return clientes.Select(c =>
            {
                c.Pass = "";
                c.Token = "";
                return c;
            });
        }

        public bool UpdateCliente(int idCliente, Cliente cliente)
        {
            string pass = cliente.Pass;
            cliente.Pass = this.CalculateHash(pass);
            return this._clientRepository.Update(idCliente, cliente);
        }

        public bool DeleteCliente(int idCliente)
        {
            return this._clientRepository.Delete(idCliente);
        }
    }
}
