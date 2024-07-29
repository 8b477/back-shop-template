
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database_Shop.Entity
{
    public class ArticleCategory
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(ArticleId))]
        public int ArticleId { get; set; }
        public Article Article { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
