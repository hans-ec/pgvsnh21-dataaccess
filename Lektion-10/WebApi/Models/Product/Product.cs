namespace WebApi.Models.Product
{
    public class Product
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
