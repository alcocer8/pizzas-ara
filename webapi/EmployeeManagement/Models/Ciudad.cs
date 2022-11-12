using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Clientes = new HashSet<Cliente>();
            Sucursals = new HashSet<Sucursal>();
        }

        public int Idciudad { get; set; }
        public string? Nombreciudad { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Sucursal> Sucursals { get; set; }
    }
}
