using System.ComponentModel.DataAnnotations;


namespace Database_Shop.Entity
{
    public class Article
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50, ErrorMessage = "Name doit contenir au maximum 50 !")]
        [MinLength(1, ErrorMessage = "Name doit contenir au minimum 2 !")]
        [Required]
        public string Name { get; set; }


        [Required]
        public ICollection<ArticleCategory> ArticleCategories { get; set; }


        [Required]
        [Range(0,10000)]
        public int Stock { get; set; }


        [Required]
        public bool Promo { get; set; }


        [Required]
        [Range(0,200)]
        public double Price { get; set; }


        public ICollection<OrderArticle> OrderArticles { get; set; }
    }
}
