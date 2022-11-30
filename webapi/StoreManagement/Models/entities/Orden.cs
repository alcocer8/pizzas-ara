using System;
using System.Collections.Generic;

namespace StoreManagement.Models.entities;

public partial class Orden
{
    public int Idorden { get; set; }

    public int? Idcliente { get; set; }

    public int? Idsucursal { get; set; }

    public int? Idcondicion { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<Detallesorden> Detallesordens { get; } = new List<Detallesorden>();

    public virtual Cliente? IdclienteNavigation { get; set; }

    public virtual Condicion? IdcondicionNavigation { get; set; }

    public virtual Sucursal? IdsucursalNavigation { get; set; }
}
