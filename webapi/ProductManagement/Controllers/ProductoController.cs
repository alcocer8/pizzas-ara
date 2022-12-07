using StoreManagement.Models.entities;
using ProductManagement.Service;
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

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult InsertProdcuto([FromBody] Producto producto)
        {
            try
            {
                var saved =_productoService.InsertarProducto (producto);
		Console.WriteLine("Name:" ,producto.Name);
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

        [HttpGet ("{idProducto}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Producto))]
        public Producto GetProducto(int idProducto)
        {
            var result = this._productoService.GetProducto(idProducto);

            if(result == null)
                return new Producto(); 

            return result;
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Producto))]
        public IEnumerable<Producto> GetProductos()
        {
            return this._productoService.GetProductos();
        }

        [HttpPut ("{Idproducto}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProducto(int idProducto, [FromBody] Producto producto)
        {
            Console.WriteLine(producto.Name);
            try
            {
                var updated = this._productoService.UpdateProdcuto(idProducto, producto);

                if (!updated)
                    return BadRequest ("Some information is wrong!");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error was raised in {nameof (ProductoController)}.{nameof (UpdateProducto)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { $"idProducto={idProducto}", $"Payload={JsonSerializer.Serialize(new Producto())}" });

                throw;
            }
        }
        


        [HttpPost ("{idProducto}") ]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProducto(int idProducto)
        {
            Console.WriteLine( $"ID: {idProducto}" );
            try
            {
                var delete =_productoService.DeleteProducto(idProducto);

                if (!delete)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (ProductoController)}.{nameof (DeleteProducto)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (new Producto()) });
                throw;
            }                        
        }
    }
}   
