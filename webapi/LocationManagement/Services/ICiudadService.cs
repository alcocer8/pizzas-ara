using System;
using LocationManagement.Models;

namespace LocationManagement.Services
{
    public interface ICiudadService
    {
        public IEnumerable<Ciudad> GetCiudades();
        public Ciudad GetCiudad(int idCiudad);
    }
}