using System;
using System.Collections.Generic;

namespace OrderManagement.Models.entities;

public partial class Municipio
{
    public int Idmunicipio { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Sucursal> Sucursals { get; } = new List<Sucursal>();
}
