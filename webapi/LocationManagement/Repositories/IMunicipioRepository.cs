using System;
using LocationManagement.Models;

namespace LocationManagement.Repositories
{
    public interface IMunicipioRepository
    {
        public IEnumerable<Municipio> GetMunicipios();
        public Municipio GetMunicipio(int idMunicipality);
    }
}