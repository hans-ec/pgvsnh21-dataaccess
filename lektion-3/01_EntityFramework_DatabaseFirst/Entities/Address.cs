using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _01_EntityFramework_DatabaseFirst.Entities
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string StreetName { get; set; } = null!;
        [StringLength(50)]
        public string PostalCode { get; set; } = null!;
        [StringLength(50)]
        public string City { get; set; } = null!;

        [InverseProperty("Address")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
