using System.ComponentModel.DataAnnotations;

namespace DomainUsage.Shared.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [StringLength(500)]
        public string LastName { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}