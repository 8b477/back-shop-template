

namespace BLL_Shop.DTO.User.Update
{
    public record UserPwdUpdateDTO
    {
        public UserPwdUpdateDTO(string pwd, string pwdConfirm)
        {
            Pwd = pwd;
            PwdConfirm = pwdConfirm;
        }

        public string Pwd { get; init; }
        public string PwdConfirm { get; init; }
    }
}
