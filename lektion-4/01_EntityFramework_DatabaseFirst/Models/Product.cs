namespace _01_EntityFramework_DatabaseFirst.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Barcode { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Modified { get; set; }

        public string CategoryName { get; set; } = null!;
        public string SubCategoryName { get; set; } = null!;
        public string VendorName { get; set; } = null!;

    }
}
