using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _04_DataAccess_EntityFrameworkCore.CodeFirst.Models.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = string.Empty;
    }
}
