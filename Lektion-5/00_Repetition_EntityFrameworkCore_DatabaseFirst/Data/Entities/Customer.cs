using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _00_Repetition_EntityFrameworkCore_DatabaseFirst.Data.Entities
{
    public partial class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;

        public int ContactPersonId { get; set; }

        [ForeignKey("ContactPersonId")]
        [InverseProperty("Customers")]
        public virtual ContactPerson ContactPerson { get; set; } = null!;
    }
}
