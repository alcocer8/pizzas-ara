using StoreManagement.Models.entities;
using StoreManagement.Service;
using StoreManagement.Service.impl;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace StoreManagement.Controllers
{
    [Route ("api/[controller]")]
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;

        private readonly IStoreService _storeService;

        public StoreController(ILogger<StoreController> logger, IStoreService storeService)
        {
            this._logger = logger;
            this._storeService = storeService;
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult InsertStore(Sucursal sucursal)
        {
            try
            {
                var saved = this._storeService.InsertStore(sucursal);

                if (!saved)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (StoreController)}.{nameof (InsertStore)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (sucursal) });

                throw;
            }           
        }

        [HttpGet ("{idSucursal}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Sucursal))]
        public Sucursal GetSucursal(int idSucursal)
        {
            var result = this._storeService.GetSucursal(idSucursal);

            if(result == null)
                return new Sucursal(); 

            return result;
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (Sucursal))]
        public IEnumerable<Sucursal> GetSucursals()
        {
            return this._storeService.GetSucursals();
        }

        [HttpPut]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateStore(int idSucursal, Sucursal sucursal)
        {
            try
            {
                var updated = this._storeService.UpdateSucursal(idSucursal, sucursal);

                if (!updated)
                    return BadRequest ("Some information is wrong!");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error was raised in {nameof (StoreController)}.{nameof (UpdateStore)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { $"idSucursal={idSucursal}", $"Payload={JsonSerializer.Serialize(new Sucursal())}" });

                throw;
            }
        }

        [HttpPost ("{idSucursal}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteStore(int idSucursal)
        {
            try
            {
                var delete = this._storeService.DeleteSucursal(idSucursal);

                if (!delete)
                    return BadRequest ("Some information is missing");

                return Ok ();
            }
            catch (Exception ex)
            {
                _logger.LogError ($"An error was raised in {nameof (StoreController)}.{nameof (DeleteStore)} method. " +
                    $"Error message {ex.Message}",
                    new object[] { JsonSerializer.Serialize (new Sucursal()) });
                throw;
            }
        }
    }
        
}