using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Database_Shop.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}
