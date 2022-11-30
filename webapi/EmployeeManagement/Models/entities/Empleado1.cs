using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models.entities
{
    public partial class Empleado
    {
        [NotMapped]
        public string? Token { get; set; }
    }
}

