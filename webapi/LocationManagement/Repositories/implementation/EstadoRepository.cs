using System;
using LocationManagement.Models;

namespace LocationManagement.Repositories.implementation
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly PizzitasContext _context;
        public EstadoRepository(PizzitasContext context)
        {
            this._context = context;
        }

        public Estado GetEstado(int idEstado)
        {
            var country = this._context.Estados.FirstOrDefault(c => c.Idestado == idEstado)!;

            return (country == null) ? new Estado() : country;
        }

        public IEnumerable<Estado> GetEstados()
        {
            return this._context.Estados;
        }
    }
}