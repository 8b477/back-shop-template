using System.ComponentModel.DataAnnotations;

namespace API_Shop.DTO.User
{
    public class UserLogDTO
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "L'adresse mail renseignée n'est pas valide !")]
        [Required(ErrorMessage = "Mail requis")]
        public string Mail { get; set; }


        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = $"8 caractères mini, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        [Required(ErrorMessage = "Mot de passe requis")]
        public string Mdp { get; set; }
    }  
}
