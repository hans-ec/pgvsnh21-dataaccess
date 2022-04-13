namespace WebApi.Models
{
    public class UserProfile
    {
        public UserProfile()
        {

        }

        public UserProfile(string addressLine, string zipCode, string city)
        {
            AddressLine = addressLine;
            ZipCode = zipCode;
            City = city;
        }

        public string AddressLine { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
