using System;
using LocationManagement.Models;

namespace LocationManagement.Services
{
    public interface IMunicipioService
    {
        public IEnumerable<Municipio> GetMunicipios();
        public Municipio GetMunicipio(int idMunicipality);
    }
}