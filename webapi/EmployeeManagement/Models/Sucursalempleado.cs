using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EmployeeManagement.Models
{
    public partial class Sucursalempleado
    {
        public int? Idsucursal { get; set; }
        public int? Idempleado { get; set; }

        [JsonIgnore]
        public virtual Empleado? IdempleadoNavigation { get; set; }
        [JsonIgnore]
        public virtual Sucursal? IdsucursalNavigation { get; set; }
    }
}
