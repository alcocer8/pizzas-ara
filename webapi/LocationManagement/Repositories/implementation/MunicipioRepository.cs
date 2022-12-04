using System;
using LocationManagement.Models;

namespace LocationManagement.Repositories.implementation
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly PizzitasContext _context;
        public MunicipioRepository(PizzitasContext context)
        {
            this._context = context;
        }

        public Municipio GetMunicipio(int idMunicipio)
        {
            var municipality = this._context.Municipios.FirstOrDefault(c => c.Idmunicipio == idMunicipio)!;

            return (municipality == null) ? new Municipio() : municipality;
        }

        public IEnumerable<Municipio> GetMunicipios()
        {
            return this._context.Municipios;
        }
    }
}