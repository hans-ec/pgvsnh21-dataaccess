using WebApi.Models;

namespace WebApi.Services
{
    public interface IUserProfileService
    {
        Task<UserProfile> CreateProfileAsync(UserProfileCreate data);
        Task<UserProfile> ReadProfileAsync(int id);
        Task<UserProfile> UpdateProfileAsync(int id, UserProfileUpdate data);

    }

    public class UserProfileService : IUserProfileService
    {
        public async Task<UserProfile> CreateProfileAsync(UserProfileCreate data)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfile> ReadProfileAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfile> UpdateProfileAsync(int id, UserProfileUpdate data)
        {
            throw new NotImplementedException();
        }
    }
}
