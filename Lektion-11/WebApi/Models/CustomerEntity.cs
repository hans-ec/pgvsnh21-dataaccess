using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class CustomerEntity
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
        private byte[] PHash { get; set; } = null!;

        [Required]
        private byte[] PSalt { get; set; } = null!;
    }
}
