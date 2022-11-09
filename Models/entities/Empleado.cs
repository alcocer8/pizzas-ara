using System;
using System.Collections.Generic;

namespace pizzitas_web.Models.entities
{
    public partial class Empleado
    {
        public int Idempleado { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Celular { get; set; }
        public int? Idcargo { get; set; }

        public virtual Cargo? IdcargoNavigation { get; set; }
    }
}
