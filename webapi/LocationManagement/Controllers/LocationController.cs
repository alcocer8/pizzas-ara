using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using LocationManagement.Models;
using LocationManagement.Services;

namespace LocationManagement.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICiudadService _ciudadService;
        private readonly IConfiguration _configuration;

        public CityController(
            ILogger<CityController> logger,
            ICiudadService ciudadService,
            IConfiguration config
        ){
            this._logger = logger;
            this._ciudadService = ciudadService;
            this._configuration = config;
        }

        [HttpGet ("{idCity}")]
        public Ciudad GetCiudad(int idCity)
        {
            return this._ciudadService.GetCiudad(idCity);
        }

        [HttpGet]
        public IEnumerable<Ciudad> GetCiudades()
        {
            return this._ciudadService.GetCiudades();
        }

        // [HttpGet ("{idCountry}")]
        // public Estado GetEstado(int idCountry)
        // {
        //     return this._estadoService.GetEstado(idCountry);
        // }

        // [HttpGet ("Countries")]
        // public IEnumerable<Estado> GetEstados()
        // {
        //     return this._estadoService.GetEstados();
        // }
    }

    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private readonly IEstadoService _estadoService;
        private readonly IConfiguration _configuration;

        public CountryController(
            ILogger<CountryController> logger,
            IEstadoService estadoService,
            IConfiguration config
        ){
            this._logger = logger;
            this._estadoService = estadoService;
            this._configuration = config;
        }

        [HttpGet ("{idCountry}")]
        public Estado GetEstado(int idCountry)
        {
            return this._estadoService.GetEstado(idCountry);
        }

        [HttpGet]
        public IEnumerable<Estado> GetEstados()
        {
            return this._estadoService.GetEstados();
        }
    }

    [Route("api/[controller]")]
    public class MunicipalityController : Controller
    {
        private readonly ILogger<MunicipalityController> _logger;
        private readonly IMunicipioService _municipioService;
        private readonly IConfiguration _configuration;

        public MunicipalityController(
            ILogger<MunicipalityController> logger,
            IMunicipioService municipioService,
            IConfiguration config
        ){
            this._logger = logger;
            this._municipioService = municipioService;
            this._configuration = config;
        }

        [HttpGet ("{idMunicipality}")]
        public Municipio GetMunicipio(int idMunicipality)
        {
            return this._municipioService.GetMunicipio(idMunicipality);
        }

        [HttpGet]
        public IEnumerable<Municipio> GetMunicipios()
        {
            return this._municipioService.GetMunicipios();
        }
    }
}