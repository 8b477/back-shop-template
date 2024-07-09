

namespace BLL_Shop.DTO.User.Update
{
    public record UserPwdUpdateDTO
    {
        public UserPwdUpdateDTO(string mdp, string mdpConfirm)
        {
            Mdp = mdp;
            MdpConfirm = mdpConfirm;
        }

        public string Mdp { get; init; }
        public string MdpConfirm { get; init; }
    }
}
