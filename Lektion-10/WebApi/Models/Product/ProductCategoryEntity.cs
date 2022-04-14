using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Product
{
    public class ProductCategoryEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }


        public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    }
}
