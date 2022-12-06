using System;
using LocationManagement.Models;
using LocationManagement.Repositories;

namespace LocationManagement.Services.implementation
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IConfiguration _configuration;
        public EstadoService(IEstadoRepository estadoRepository, IConfiguration config)
        {
            this._estadoRepository = estadoRepository;
            this._configuration = config;
        }

        public Estado GetEstado(int idCountry)
        {
            return this._estadoRepository.GetEstado(idCountry);
        }

        public IEnumerable<Estado> GetEstados()
        {
            return this._estadoRepository.GetEstados();
        }
    }
}