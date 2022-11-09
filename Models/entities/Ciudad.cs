using System;
using System.Collections.Generic;

namespace pizzitas_web.Models.entities
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Clientes = new HashSet<Cliente>();
            Sucursals = new HashSet<Sucursal>();
        }

        public int Idciudad { get; set; }
        public string? Nombreciudad { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Sucursal> Sucursals { get; set; }
    }
}
