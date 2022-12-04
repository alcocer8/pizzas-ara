using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LocationManagement.Models;

public partial class Municipio
{
    public int Idmunicipio { get; set; }

    public string? Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();
    [JsonIgnore]
    public virtual ICollection<Sucursal> Sucursals { get; } = new List<Sucursal>();
}
