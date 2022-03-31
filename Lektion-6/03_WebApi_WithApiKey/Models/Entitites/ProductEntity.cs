using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _03_WebApi_WithApiKey.Models.Entitites
{
    [Index(nameof(Name), IsUnique = true)]
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required, Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null!;
    }
}
