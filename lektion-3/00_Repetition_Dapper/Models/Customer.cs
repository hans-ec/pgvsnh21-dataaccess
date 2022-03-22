namespace _00_Repetition_Dapper.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
