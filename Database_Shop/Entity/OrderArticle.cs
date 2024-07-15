
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database_Shop.Entity
{
    public class OrderArticle
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(OrderId))]
        public int OrderId { get; set; }

        public Order Order { get; set; }


        [ForeignKey(nameof(ArticleId))]
        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }

}
