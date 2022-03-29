namespace _01_EntityFrameworkCore_CodeFirst.Models.Forms
{
    public class CustomerForm
    {
        public string CustomerName { get; set; } = null!;
        public ContactPersonForm ContactPerson { get; set; } = new();
    }

    public class ContactPersonForm
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
