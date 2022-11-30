using System;
using System.Collections.Generic;

namespace StoreManagement.Models.entities;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string? Name { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<Detallesorden> Detallesordens { get; } = new List<Detallesorden>();
}
