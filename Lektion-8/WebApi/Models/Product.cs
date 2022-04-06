namespace WebApi.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(int id, string name, decimal price, string categoryName)
        {
            Id = id;
            Name = name;
            Price = price;
            CategoryName = categoryName;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
