using _00_Repetition_ServiceLifeTimes.Models;

namespace _00_Repetition_ServiceLifeTimes.Services
{
    public interface IProfileManager
    {
        UserProfile GetProfile();
    }


    public class ProfileManager : IProfileManager
    {
        private UserProfile _profile;

        public ProfileManager()
        {
            _profile = new UserProfile
            {
                Id = Guid.NewGuid(),
                Name = "Hans Mattin-Lassei",
                Address = "Nordkapsvägen 1",
                PostalCode = "136 57",
                City = "Vega"
            };
        }

        public UserProfile GetProfile()
        {
            return _profile;
        }
    }
}
