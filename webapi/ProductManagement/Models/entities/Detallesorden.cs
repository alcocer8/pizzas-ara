using System;
using System.Collections.Generic;

namespace ProductManagement.Models.entities;

public partial class Detallesorden
{
    public int Iddetalles { get; set; }

    public int? Idorden { get; set; }

    public int? Idproducto { get; set; }

    public int? Quantity { get; set; }

    public virtual Orden? IdordenNavigation { get; set; }

    public virtual Producto? IdproductoNavigation { get; set; }
}
