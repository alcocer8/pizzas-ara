using System;
using LocationManagement.Models;

namespace LocationManagement.Repositories.implementation
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly PizzitasContext _context;
        public CiudadRepository(PizzitasContext context)
        {
            this._context = context;
        }
        public Ciudad GetCiudad(int idCiudad)
        {
            var city = this._context.Ciudads.FirstOrDefault(c => c.Idciudad == idCiudad)!;

            return (city == null) ? new Ciudad() : city;
        }

        public IEnumerable<Ciudad> GetCiudades()
        {
            return this._context.Ciudads;
        }
    }
}