

namespace BLL_Shop.DTO.User.Create
{
    public record UserCreateDTO
    {
        public UserCreateDTO(int? phoneNumber, string pseudo, string mail, string mdp, string mdpConfirm)
        {
            PhoneNumber = phoneNumber;
            Pseudo = pseudo;
            Mail = mail;
            Mdp = mdp;
            MdpConfirm = mdpConfirm;
            Role = "User";
        }

        public int? PhoneNumber { get; init; }
        public string Pseudo { get; init; }
        public string Mail { get; init; }
        public string Mdp { get; init; }
        public string MdpConfirm { get; init; }
        public string Role { get; init; }
    }
}
