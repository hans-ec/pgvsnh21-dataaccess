using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _03_DataAccess_EntityFrameworkCore.DatabaseFirst.Models
{
    [Index("Name", Name = "UQ__Categori__737584F62D33FD37", IsUnique = true)]
    public partial class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = null!;
    }
}
