using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Database_Shop.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1,ErrorMessage = "Le nom de la catégorie doit contenir au moins 1 caractère")]
        [MaxLength(50, ErrorMessage = "Le nom de la catégorie doit contenir au maximum 50 caractères")]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}
