using System;
using System.Collections.Generic;

namespace LocationManagement.Models;

public partial class Condicion
{
    public int Idcondicion { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Orden> Ordens { get; } = new List<Orden>();
}
