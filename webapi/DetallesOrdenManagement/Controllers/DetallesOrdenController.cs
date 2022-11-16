using DetallesOrdenManagement.Models.entities;
using DetallesOrdenManagement.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DetallesOrdenManagement.Controllers
{
    [Route("api/[controller]")]
    public class DetallesOrdenController : Controller
    {
        private readonly ILogger<DetallesOrdenController> _logger;
        private readonly IDetallesOrdenService _detallesOrdenService;

        public DetallesOrdenController(
            ILogger<DetallesOrdenController> logger,
            IDetallesOrdenService detallesOrdenService
        ){
            this._detallesOrdenService = detallesOrdenService;
            this._logger = logger;
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult InsertDetallesOrden(Detallesorden detallesOrden)
        {
            try
            {
                var saved = this._detallesOrdenService.InsertDetallesOrden(detallesOrden);

                if (!saved)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (DetallesOrdenController)}.{nameof (InsertDetallesOrden)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (detallesOrden) });

                throw;
            }
        }

        [HttpGet ("{idDetallesOrden}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Detallesorden))]
        public Detallesorden GetDetallesorden(int idDetallesOrden)
        {
            var result = this._detallesOrdenService.GetDetallesorden(idDetallesOrden);

            if(result == null)
                return new Detallesorden(); 

            return result;
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Detallesorden))]
        
        public IEnumerable<Detallesorden> GetDetallesordens()
        {
            return this._detallesOrdenService.GetDetallesordens();
        }

        [HttpPost ("{idDetallesOrden}") ]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteDetallesOrden(int idDetallesOrden)
        {
            try
            {
                var delete = this._detallesOrdenService.DeleteDetallesOrden(idDetallesOrden);

                if (!delete)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (DetallesOrdenController)}.{nameof (Detallesorden)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (new Detallesorden()) });
                throw;
            }                        
        }

    }

}