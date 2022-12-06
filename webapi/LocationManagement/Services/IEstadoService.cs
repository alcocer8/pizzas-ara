using System;
using LocationManagement.Models;

namespace LocationManagement.Services
{
    public interface IEstadoService
    {
        public IEnumerable<Estado> GetEstados();
        public Estado GetEstado(int idCountry);
    }
}