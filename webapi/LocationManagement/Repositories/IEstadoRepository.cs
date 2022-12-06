using System;
using LocationManagement.Models;

namespace LocationManagement.Repositories
{
    public interface IEstadoRepository
    {
        public IEnumerable<Estado> GetEstados();
        public Estado GetEstado(int idEstado);
    }
}