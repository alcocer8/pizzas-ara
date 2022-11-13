using System;
using System.Collections.Generic;

namespace pizzitas_web.Models.entities
{
    public partial class Estado
    {
        public Estado()
        {
            Clientes = new HashSet<Cliente>();
            Sucursals = new HashSet<Sucursal>();
        }

        public int Idestado { get; set; }
        public string? Nombreestado { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Sucursal> Sucursals { get; set; }
    }
}
