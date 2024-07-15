using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Database_Shop.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }


        [MaxLength(50, ErrorMessage = "Status doit contenir au maximum 50 !")]
        [MinLength(2, ErrorMessage = "Status doit contenir au minimum 2 !")]
        [Required(ErrorMessage = "Status requis")]
        public string Status { get; set; }


        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "La date de création est requise.")]
        public DateTime CreatedAt { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? SentAt { get; set; }


        public ICollection<OrderArticle> OrderArticles { get; set; }


        public User User { get; set; }
    }
}
