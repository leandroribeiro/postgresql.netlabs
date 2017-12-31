using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgre.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }
        
    }
}