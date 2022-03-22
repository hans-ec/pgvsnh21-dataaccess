using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _01_EntityFramework_DatabaseFirst.Entities
{
    public partial class Customer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        public string Email { get; set; } = null!;
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Customers")]
        public virtual Address Address { get; set; } = null!;
    }
}
