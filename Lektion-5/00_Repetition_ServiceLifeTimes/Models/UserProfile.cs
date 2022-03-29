namespace _00_Repetition_ServiceLifeTimes.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
