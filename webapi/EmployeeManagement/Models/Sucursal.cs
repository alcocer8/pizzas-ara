using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EmployeeManagement.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Ordens = new HashSet<Orden>();
        }

        public int Idsucursal { get; set; }
        public string? Name { get; set; }
        public string? Calle { get; set; }
        public string? Colonia { get; set; }
        public short? Ninterior { get; set; }
        public short? Nexterior { get; set; }
        public string? Cp { get; set; }
        public int? Idmunicipio { get; set; }
        public int? Idciudad { get; set; }
        public int? Idestado { get; set; }
        [JsonIgnore]
        public virtual Ciudad? IdciudadNavigation { get; set; }
        [JsonIgnore]
        public virtual Estado? IdestadoNavigation { get; set; }
        [JsonIgnore]
        public virtual Municipio? IdmunicipioNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
