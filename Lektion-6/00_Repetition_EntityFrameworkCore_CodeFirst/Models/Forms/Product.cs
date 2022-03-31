namespace _00_Repetition_EntityFrameworkCore_CodeFirst.Models.Forms
{
    public class Product
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
    }
}
