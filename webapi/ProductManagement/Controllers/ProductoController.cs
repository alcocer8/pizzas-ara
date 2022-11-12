using pizzitas_web.Models.entities;
using pizzitas_web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace pizzitas_web.Controllers
{
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoService _productoService;

        public ProductoController(
            ILogger<ProductoController> logger,
            IProductoService productoService
        ){
            this._logger = logger;
            this._productoService = productoService;
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Producto))]
        public Producto GetProducto(int idProduct)
        {
            var result = this._productoService.GetProducto(idProduct);

            if(result == null)
                return new Producto(); 

            return result;
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult InsertProdcuto(Producto producto)
        {
            try
            {
                var saved =_productoService.InsertarProducto (producto);

                if (!saved)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (ProductoController)}.{nameof (InsertProdcuto)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (producto) });

                throw;
            }
        }
    }
}