namespace _03_WebApi_WithApiKey.Models.Forms
{
    public class Product
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
    }
}
