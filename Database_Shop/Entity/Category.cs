using System.ComponentModel.DataAnnotations;


namespace Database_Shop.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<ArticleCategory> ArticleCategories { get; set; }
    }

}
