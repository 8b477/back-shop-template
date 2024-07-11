using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database_Shop.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }


        [DataType(DataType.PhoneNumber, ErrorMessage = "Le numéro de téléphone renseigné n'est pas valide.")]
        public string? PhoneNumber { get; set; }


        [Range(1, 99999, ErrorMessage = "Le code postal n'est pas valide !")]
        [Required(ErrorMessage = "Code postal requis")]
        public int PostalCode { get; set; }


        [Required(ErrorMessage = "Numéro de rue requis")]
        [Range(1, 9401, ErrorMessage = "Le numéro de rue doit être compris entre 1 et 9401")]
        public int StreetNumber { get; set; }


        [MaxLength(35)]
        [Required(ErrorMessage = "Pays requis")]
        public string Country { get; set; }


        [MaxLength(85)]
        [Required(ErrorMessage = "La ville est requis")]
        public string City { get; set; }


        [ForeignKey(nameof(UserId))]
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}

 