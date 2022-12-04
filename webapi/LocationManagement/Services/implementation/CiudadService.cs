using System;
using LocationManagement.Models;
using LocationManagement.Repositories;

namespace LocationManagement.Services.implementation
{
    public class CiudadService : ICiudadService
    {
        private readonly ICiudadRepository _ciudadRepository;
        private readonly IConfiguration _configuration;
        public CiudadService(ICiudadRepository ciudadRepository, IConfiguration config)
        {
            this._ciudadRepository = ciudadRepository;
            this._configuration = config;
        }

        public Ciudad GetCiudad(int idCiudad)
        {
            return this._ciudadRepository.GetCiudad(idCiudad);
        }

        public IEnumerable<Ciudad> GetCiudades()
        {
            return this._ciudadRepository.GetCiudades();
        }
    }
}