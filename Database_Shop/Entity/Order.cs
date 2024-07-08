using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Database_Shop.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(Id_User))]
        public int Id_User { get; set; }


        [MaxLength(50, ErrorMessage = "Status doit contenir au maximum 50 !")]
        [MinLength(2, ErrorMessage = "Status doit contenir au minimum 2 !")]
        [Required(ErrorMessage = "Status requis")]
        public string Status { get; set; }


        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreateAt { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime SendAt { get; set; }


        public ICollection<Article> Articles { get; set; }
    }
}
