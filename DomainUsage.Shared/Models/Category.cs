using System.Collections.Generic;

namespace DomainUsage.Shared.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}