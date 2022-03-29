using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _00_Repetition_EntityFrameworkCore_DatabaseFirst.Data.Entities
{
    public partial class ContactPerson
    {
        public ContactPerson()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int Id { get; set; }
        
        
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [StringLength(100)]
        public string Email { get; set; } = null!;

        [InverseProperty("ContactPerson")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
