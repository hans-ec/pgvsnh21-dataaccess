using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_Repetition_WebApiKey.Models.Entitites
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = null!;
        
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
