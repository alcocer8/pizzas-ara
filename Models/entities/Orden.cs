using System;
using System.Collections.Generic;

namespace pizzitas_web.Models.entities
{
    public partial class Orden
    {
        public int Idorden { get; set; }
        public int? Idcliente { get; set; }
        public int? Idsucursal { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Cliente? IdclienteNavigation { get; set; }
        public virtual Sucursal? IdsucursalNavigation { get; set; }
    }
}
