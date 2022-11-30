using ClientManagement.Models.entities;
using ClientManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;


namespace ClientManagement.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClienteService _clienteService;

        public ClientController
        (
            ILogger<ClientController> logger,
            IClienteService clienteService
        ){
            this._clienteService = clienteService;
            this._logger = logger;
        }

        [HttpPost ("authenticate")]
        [AllowAnonymous]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Cliente))]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult Authenticate([FromBody] Login login)
        {
            
            var result = this._clienteService.Authenticate (login.Username, login.Password);
            return Ok (result);
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult InsertClient(Cliente cliente)
        {
            try
            {
                var saved = this._clienteService.InsertClient(cliente);

                if (!saved)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (ClientController)}.{nameof (InsertClient)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (cliente) });

                throw;
            }
        }

        [HttpGet ("{idCliente}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Cliente))]
        public Cliente GetCliente(int idCliente)
        {
            var result = this._clienteService.GetCliente(idCliente);

            if(result == null)
                return new Cliente(); 

            return result;
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Cliente))]
        public IEnumerable<Cliente> GetClientes()
        {
            return this._clienteService.GetClientes();
        }
    
        [HttpPut]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateClient(int idCliente, Cliente cliente)
        {
            try
            {
                var updated = this._clienteService.UpdateCliente(idCliente, cliente);

                if (!updated)
                    return BadRequest ("Some information is wrong!");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error was raised in {nameof (ClientController)}.{nameof (UpdateClient)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { $"idCliente={idCliente}", $"Payload={JsonSerializer.Serialize(new Cliente())}" });

                throw;
            }
        }

        [HttpPost ("{idCliente}") ]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCliente(int idCliente)
        {
            try
            {
                var delete = this._clienteService.DeleteCliente(idCliente);

                if (!delete)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (ClientController)}.{nameof (DeleteCliente)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (new Cliente()) });
                throw;
            }                        
        }

    }
}