using System.ComponentModel.DataAnnotations;

namespace Database_Shop.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Pseudo requis")]
        [MinLength(2, ErrorMessage = "Le champ pseudo doit contenir au minimum 2 caractères")]
        [MaxLength(50, ErrorMessage = "Le champ pseudo doit contenir au maximum 50 caractères")]
        public string Pseudo { get; set; }


        [Required(ErrorMessage = "Mail requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = "L'adresse mail renseignée n'est pas valide")]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Mot de passe requis")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "8 caractères mini, 1 majuscule, 1 minuscule, 1 chiffre et 1 charactère spécial")]
        public string Pwd { get; set; }


        public string Role { get; set; }


        public Address? Address { get; set; }


        public List<Order>? Orders { get; set; }
    }
}
