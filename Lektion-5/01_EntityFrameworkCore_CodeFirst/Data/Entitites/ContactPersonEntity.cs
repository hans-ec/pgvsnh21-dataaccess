using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_EntityFrameworkCore_CodeFirst.Data.Entitites
{
    [Index(nameof(Email), IsUnique = true)]
    public class ContactPersonEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; } = null!;

        public virtual ICollection<CustomerEntity> Customers { get; set; }
    }
}




/*   
    C#                          SQL
    ------------------------------------------------------------------------
    int                         tinyint,smallint,int
    long                        bigint
    decimal                     decimal, money
    double                      decimal, money
    float                       float
    bool                        bit
    Guid                        uniqueidentifier
    string                      char, nchar, varchar, nvarchar, text, ntext
*/