using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_EntityFrameworkCore_CodeFirst.Data.Entitites
{

    [Index(nameof(Name), IsUnique = true)]
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = null!;

        [Required]
        public int ContactPersonId { get; set; }

        public virtual ContactPersonEntity ContactPerson { get; set; }
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