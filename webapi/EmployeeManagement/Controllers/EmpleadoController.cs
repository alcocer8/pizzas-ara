using EmployeeManagement.Models.entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;


namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly ILogger<EmpleadoController> _logger;
        private readonly IEmpleadoService _empleadoService;
        private readonly IConfiguration _configuration;

        public EmpleadoController(
            ILogger<EmpleadoController> logger,
            IEmpleadoService empleadoService,
            IConfiguration configuration
        ){
            this._logger = logger;
            this._empleadoService = empleadoService;
            this._configuration = configuration;
        }

        [HttpPost ("authenticate")]
        [AllowAnonymous]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Empleado))]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult Authenticate([FromBody] Login login)
        {
            
            var result = this._empleadoService.Authenticate (login.Username, login.Password);
            return Ok (result);
        }

        //[Authorize (Roles = "Administrador")]
        [HttpGet ("{idEmployee}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Empleado))]
        public Empleado GetEmployee(int idEmployee)
        {
            var result = this._empleadoService.GetEmpleado(idEmployee);

            if(result == null)
                return new Empleado(); 

            return result;
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof(IEnumerable<Empleado>))]
        public IEnumerable<Empleado> GetEmployees() 
        {
            return this._empleadoService.GetEmpleados();
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult InsertEmployee([FromBody] Empleado empleado)
        {
            try
            {
                var saved =_empleadoService.InsertarEmpleado (empleado);

                if (!saved)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (EmpleadoController)}.{nameof (InsertEmployee)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (empleado) });

                throw;
            }
        }

        [HttpPut ("{Idempleado}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEmpleado(int idEmpleado, [FromBody] Empleado empleado)
        {
            try
            {
                var updated = this._empleadoService.UpdateEmpleado(idEmpleado, empleado);

                if (!updated)
                    return BadRequest ("Some information is wrong!");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error was raised in {nameof (EmpleadoController)}.{nameof (UpdateEmpleado)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { $"idEmpleado={idEmpleado}", $"Payload={JsonSerializer.Serialize(new Empleado())}" });

                throw;
            }
        }

        [HttpDelete ("{Idempleado}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public bool DeleteEmployee(int Idempleado) 
        {
            Console.WriteLine(Idempleado);
            var isDeleted = this._empleadoService.DeleteEmpleado(Idempleado);

            return isDeleted;
        }
    }
}
