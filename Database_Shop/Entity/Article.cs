using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Database_Shop.Entity
{
    public class Article
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Nom de l'article requis")]
        [MinLength(1, ErrorMessage = "Le nom doit contenir au minimum 1 caractère")]
        [MaxLength(50, ErrorMessage = "Le nom doit contenir au maximum 50 caractères")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Un article doit appartenir au minimum à une catégorie")]
        public ICollection<ArticleCategory> ArticleCategories { get; set; }


        [Required(ErrorMessage = "Le nombre d'articles en stock est requis")]
        [Range(0,10000)]
        public int Stock { get; set; }


        [Required(ErrorMessage = "Le champ 'promo' est requis l'article, valeur attendu : 'false' ou 'true'")]
        public bool Promo { get; set; }


        [Required(ErrorMessage = "Le prix de l'article est requis")]
        [Range(0,200, ErrorMessage = "Le prix de l'article doit être compris entre les valeurs 0 et 200")]
        public double Price { get; set; }

        [JsonIgnore]
        public List<OrderArticle> OrdersArticles { get; set; }
    }
}
