namespace _01_EntityFrameworkCore_CodeFirst.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public ContactPerson ContactPerson { get; set; } = null!;
    }
}
