

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

        public required int? PhoneNumber { get; init; }
        public required string Pseudo { get; init; }
        public required string Mail { get; init; }
        public required string Mdp { get; init; }
        public required string MdpConfirm { get; init; }
        public required string Role { get; init; }
    }
}
