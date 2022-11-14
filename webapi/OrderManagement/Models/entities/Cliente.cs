using System;
using System.Collections.Generic;

namespace OrderManagement.Models.entities;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Phone { get; set; }

    public string? Calle { get; set; }

    public string? Colonia { get; set; }

    public short? Ninterior { get; set; }

    public short? Nexterior { get; set; }

    public string? Cp { get; set; }

    public string? Referencias { get; set; }

    public int? Idmunicipio { get; set; }

    public int? Idciudad { get; set; }

    public int? Idestado { get; set; }

    public virtual Ciudad? IdciudadNavigation { get; set; }

    public virtual Estado? IdestadoNavigation { get; set; }

    public virtual Municipio? IdmunicipioNavigation { get; set; }

    public virtual ICollection<Orden> Ordens { get; } = new List<Orden>();
}
