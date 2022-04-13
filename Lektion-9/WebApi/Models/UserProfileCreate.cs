namespace WebApi.Models
{
    public class UserProfileCreate
    {
        public UserProfileCreate()
        {

        }

        public UserProfileCreate(int userId, string addressLine, string zipCode, string city)
        {
            UserId = userId;
            AddressLine = addressLine;
            ZipCode = zipCode;
            City = city;
        }

        public int UserId { get; set; }
        public string AddressLine { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
