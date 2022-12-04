using System;
using LocationManagement.Models;
using LocationManagement.Repositories;

namespace LocationManagement.Services.implementation
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IConfiguration _configuration;
        public MunicipioService(IMunicipioRepository municipioRepository, IConfiguration config)
        {
            this._municipioRepository = municipioRepository;
            this._configuration = config;
        }

        public Municipio GetMunicipio(int idMunicipality)
        {
            return this._municipioRepository.GetMunicipio(idMunicipality);
        }

        public IEnumerable<Municipio> GetMunicipios()
        {
            return this._municipioRepository.GetMunicipios();
        }
    }
}