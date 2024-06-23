using System.ComponentModel.DataAnnotations;

namespace API_Shop.DTO.Address
{
    public class AddressUpdateDTO
    {
        [DataType(DataType.PostalCode, ErrorMessage = "Le code postal n'est pas valide !")]
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
    }
}
