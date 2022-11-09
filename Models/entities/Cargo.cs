using System;
using System.Collections.Generic;

namespace pizzitas_web.Models.entities
{
    public partial class Cargo
    {
        public Cargo()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Idcargo { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
