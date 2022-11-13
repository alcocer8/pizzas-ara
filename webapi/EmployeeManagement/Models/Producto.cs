using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public partial class Producto
    {
        public int Idproducto { get; set; }
        public string? Name { get; set; }
        public decimal? Precio { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
    }
}
