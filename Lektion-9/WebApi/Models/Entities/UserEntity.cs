using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Models.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {

        }

        public UserEntity(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        private byte[] Hash { get; set; } = null!;

        [Required]
        private byte[] Salt { get; set; } = null!;


        public bool CompareSecurePassword(string password)
        {
            bool response = false;

            using (var hmac = new HMACSHA512(Salt))
            {
                var _hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < _hash.Length; i++)
                    if (_hash[i] != Hash[i])
                        response = false;
                    else
                        response = true;
            }

            return response;
        }

        public void CreateSecurePassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                Salt = hmac.Key;
                Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
