﻿using System.ComponentModel.DataAnnotations;

namespace Database_Shop.Entity
{
#nullable disable
    public class User
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50, ErrorMessage = "Pseudo doit contenir au maximum 50 !")]
        [MinLength(2, ErrorMessage = "Pseudo doit contenir au minimum 2 !")]
        [Required(ErrorMessage = "Pseudo requis")]
        public string Pseudo { get; set; }


        [DataType(DataType.EmailAddress, ErrorMessage = "L'adresse mail renseignée n'est pas valide !")]
        [Required(ErrorMessage = "Mail requis")]
        public string Mail { get; set; }


        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = $"8 caractères mini, 1 majuscule, 1 minuscule, 1 chiffre et 1 caractère spécial")]
        [Required(ErrorMessage = "Mot de passe requis")]
        public string Mdp { get; set; }


        [Compare(nameof(Mdp), ErrorMessage = "Le champ mot de passe et celui de la confirmation du mot de passe ne corresponde pas !")]
        [Required(ErrorMessage = "Confirmation du mot de passe requise")]
        public string MdpConfirm { get; set; }


        public string Role { get; set; }


        public Address? Address { get; set; }


        public List<Order>? Orders { get; set; }
    }
#nullable enable
}
