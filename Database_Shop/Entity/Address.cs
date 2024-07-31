using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Database_Shop.Entity
{
    public class Address
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(20, ErrorMessage = "Numéro de téléphone incorrect, il doit contenir moins de 20 caractères")]
        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = "Code postal requis")]
        [MinLength(1, ErrorMessage = "Code postal incorrect, il doit contenir au moins 1 caractère")]
        [MaxLength(20, ErrorMessage = "Code postal incorrect, il doit contenir moins de 20 caractères")]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "Numéro de rue requis")]
        [MinLength(1, ErrorMessage = "Numéro de rue incorrect, il doit contenir au moins 1 caractère")]
        [MaxLength(20, ErrorMessage = "Numéro de rue incorrect, il doit contenir moins de 20 caractères")]
        public string StreetNumber { get; set; }


        [Required(ErrorMessage = "Nom de la rue requis")]
        [MinLength(1, ErrorMessage = "Nom de la rue incorrect, celle-ci doit contenir au moins 1 caractère")]
        [MaxLength(50, ErrorMessage = "Nom de la rue incorrect, celle-ci doit contenir moins de 50 caractères")]
        public string StreetName { get; set; }


        [Required(ErrorMessage = "Pays requis")]
        [MinLength(1, ErrorMessage = "Pays incorrect, celle-ci doit contenir au moins 1 caractère")]
        [MaxLength(50, ErrorMessage = "Pays incorrect, celle-ci doit contenir moins de 50 caractères")]
        public string Country { get; set; }


        [Required(ErrorMessage = "La ville est requis")]
        [MinLength(1, ErrorMessage = "La ville incorrect, celle-ci doit contenir au moins 1 caractères")]
        [MaxLength(50, ErrorMessage = "La ville incorrect, celle-ci doit contenir moins de 50 caractères")]
        public string City { get; set; }


        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}

