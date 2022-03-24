using System.ComponentModel.DataAnnotations;

namespace _01_EntityFramework_DatabaseFirst.Models.Forms
{
    public class ProductForm
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string CategoryName { get; set; } = null!;

        [Required]
        public string SubCategoryName { get; set; } = null!;

        [Required]
        public string Vendor { get; set; } = null!;

        public string? Barcode { get; set; }
        public string? Description { get; set; }
    }
}
