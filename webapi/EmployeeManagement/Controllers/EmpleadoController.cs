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

        [HttpPut]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
            public bool UpdateEmployee(int idEmployee, Empleado empleado)
        {
            return this._empleadoService.UpdateEmpleado(idEmployee, empleado);
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult InsertEmployee(Empleado empleado)
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

        [HttpDelete]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public bool DeleteEmployee(int employeeId) 
        {
            var isDeleted = this._empleadoService.DeleteEmpleado(employeeId);

            return isDeleted;
        }
    }
}