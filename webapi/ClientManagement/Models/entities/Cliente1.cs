using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClientManagement.Models.entities
{
    public partial class Cliente
    {
        [NotMapped]
        public string? Token { get; set; }
    }
}

