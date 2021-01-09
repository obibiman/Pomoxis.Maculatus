using System.Collections.Generic;

namespace DomainUsage.Shared.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Content { get; set; }
        public Author Author { get; set; }
        public ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}