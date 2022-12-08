using OrderManagement.Models.entities;
using OrderManagement.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace OrderManagement.Controllers
{
    [Route ("api/[controller]")]
    public class OrderController : Controller
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(
            ILogger<OrderController> logger,
            IOrderService orderService
        ){
            this._logger = logger;
            this._orderService = orderService;
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult InsertOrder(Orden orden)
        {
            try
            {
                var saved = this._orderService.InsertOrder (orden);

                if (!saved)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (OrderController)}.{nameof (InsertOrder)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (orden) });

                throw;
            }
        }

        

        [HttpGet ("{idOrden}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Producto))]
        public Orden GetOrden(int idOrden)
        {
            var result = this._orderService.GetOrden(idOrden);

            if(result == null)
                return new Orden(); 

            return result;
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Producto))]
        public IEnumerable<Orden> GetOrdens()
        {
            return this._orderService.GetOrdens();
        }

        [HttpPut]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateOrden([FromBody] OrdenGet values)
        {
            Console.WriteLine($" IdOrden: {values.idOrden}, IdCondicion: {values.idCondicion} ");
            try
            {
                var updated = this._orderService.UpdateOrden(values.idOrden, values.idCondicion);

                if (!updated)
                    return BadRequest ("Some information is wrong!");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error was raised in {nameof (OrderController)}.{nameof (UpdateOrden)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { $"idOrden={values.idOrden}", $"Payload={JsonSerializer.Serialize(new Orden())}" });

                throw;
            }
        }

        [HttpPost ("{idOrden}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteOrden(int idOrden)
        {
            try
            {
                var delete = this._orderService.DeleteOrden(idOrden);

                if (!delete)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (OrderController)}.{nameof (DeleteOrden)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (new Orden()) });
                throw;
            }
        }

    }
}