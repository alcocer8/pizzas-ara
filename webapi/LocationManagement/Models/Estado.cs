using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LocationManagement.Models;

public partial class Estado
{
    public int Idestado { get; set; }

    public string? Nombreestado { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();
    [JsonIgnore]
    public virtual ICollection<Sucursal> Sucursals { get; } = new List<Sucursal>();
}
