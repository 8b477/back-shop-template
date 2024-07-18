

namespace BLL_Shop.DTO.User.Update
{
    public record UserPwdUpdateDTO
    {
        public UserPwdUpdateDTO(string mdp, string mdpConfirm)
        {
            Mdp = mdp;
            MdpConfirm = mdpConfirm;
        }

        public required string Mdp { get; init; }
        public required string MdpConfirm { get; init; }
    }
}
