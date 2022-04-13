using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Entities;
using WebApi.Models.Forms;

namespace WebApi.Services
{
    public interface IUserService
    {
        Task<UserModel> CreateAsync(UserCreateForm data);
        Task<UserModel> ReadAsync(int id);
        Task<IEnumerable<UserModel>> ReadAllAsync();
        Task<UserModel> UpdateAsync(int id, UserUpdateForm data);
        Task<bool> DeleteAsync(int id);
    }

    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<UserModel> CreateAsync(UserCreateForm data)
        {
            if (!await _context.Users.AnyAsync(x => x.Email == data.Email))
            {
                var userEntity = new UserEntity(data.FirstName,data.LastName,data.Email);
                userEntity.CreateSecurePassword(data.Password);

                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync();

                return new UserModel(userEntity.Id, userEntity.FirstName, userEntity.LastName, userEntity.Email);
            }

            return null!;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if(userEntity != null)
            {
                _context.Users.Remove(userEntity);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<UserModel>> ReadAllAsync()
        {
            var users = new List<UserModel>();
            foreach (var u in await _context.Users.ToListAsync())
                users.Add(new UserModel(u.Id, u.FirstName, u.LastName, u.Email));

            return users;
        }

        public async Task<UserModel> ReadAsync(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity != null)
                return new UserModel(userEntity.Id, userEntity.FirstName, userEntity.LastName, userEntity.Email);

            return null!;
        }

        public async Task<UserModel> UpdateAsync(int id, UserUpdateForm data)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if(userEntity != null)
            {
                userEntity.FirstName = data.FirstName;
                userEntity.LastName = data.LastName;
                _context.Entry(userEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new UserModel(userEntity.Id, userEntity.FirstName, userEntity.LastName, userEntity.Email);
            }

            return null!;
        }
    }
}