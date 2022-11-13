using System;
using System.Collections.Generic;

namespace pizzitas_web.Models.entities
{
    public partial class Municipio
    {
        public Municipio()
        {
            Clientes = new HashSet<Cliente>();
            Sucursals = new HashSet<Sucursal>();
        }

        public int Idmunicipio { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Sucursal> Sucursals { get; set; }
    }
}
