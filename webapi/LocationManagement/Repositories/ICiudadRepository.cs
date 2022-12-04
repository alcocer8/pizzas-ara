using System;
using LocationManagement.Models;

namespace LocationManagement.Repositories
{
    public interface ICiudadRepository
    {
        public IEnumerable<Ciudad> GetCiudades();
        public Ciudad GetCiudad(int idCiudad);
    }
}