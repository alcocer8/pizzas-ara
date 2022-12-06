using System;
using System.Collections.Generic;

namespace LocationManagement.Models;

public partial class Cargo
{
    public int Idcargo { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
