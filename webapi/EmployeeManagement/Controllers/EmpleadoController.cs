using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly ILogger<EmpleadoController> _logger;
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(
            ILogger<EmpleadoController> logger,
            IEmpleadoService empleadoService
        ){
            this._logger = logger;
            this._empleadoService = empleadoService;
        }

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
        public bool UpdateEmployee(int idEmployee, [FromBody] Empleado empleado)
        {
            return this._empleadoService.UpdateEmpleado(idEmployee, empleado);
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
    }
}