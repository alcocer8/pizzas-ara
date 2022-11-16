using System;
using System.Collections.Generic;

namespace StoreManagement.Models.entities;

public partial class Estado
{
    public int Idestado { get; set; }

    public string? Nombreestado { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Sucursal> Sucursals { get; } = new List<Sucursal>();
}
