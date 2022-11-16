using System;
using System.Collections.Generic;

namespace DetallesOrdenManagement.Models.entities;

public partial class Ciudad
{
    public int Idciudad { get; set; }

    public string? Nombreciudad { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Sucursal> Sucursals { get; } = new List<Sucursal>();
}
