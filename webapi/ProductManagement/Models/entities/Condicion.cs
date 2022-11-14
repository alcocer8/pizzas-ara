using System;
using System.Collections.Generic;

namespace ProductManagement.Models.entities;

public partial class Condicion
{
    public int Idcondicion { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Orden> Ordens { get; } = new List<Orden>();
}
