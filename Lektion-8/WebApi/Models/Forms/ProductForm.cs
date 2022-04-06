namespace WebApi.Models.Forms
{
    public class ProductForm
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
