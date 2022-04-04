using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace _01_WebApi_Authentication.Models.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; } = null!;
        
        [Required]
        public string LastName { get; set; } = null!;
        
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public byte[] PasswordHash { get; private set; }
        
        [Required]
        public byte[] Salt { get; private set; }


        public void CreateSecurePassword(string password)
        {
            using var hmac = new HMACSHA512();
            Salt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            hmac.Clear();
        }

        public bool CompareSecurePassword(string password)
        {
            using (var hmac = new HMACSHA512(Salt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != PasswordHash[i])
                        return false;
                }
            }

            return true;
        }

    }
}
