namespace BLL_Shop.DTO.User.Update
{
    public record UserUpdateDTO
    {
        public UserUpdateDTO(int? phoneNumber, string pseudo, string mail, string pwd, string mdpConfirm)
        {
            PhoneNumber = phoneNumber;
            Pseudo = pseudo;
            Mail = mail;
            Pwd = pwd;
            MdpConfirm = mdpConfirm;
            Role = "User";
        }

        public int? PhoneNumber { get; init; }
        public string Pseudo { get; init; }
        public string Mail { get; init; }
        public string Pwd { get; init; }
        public string MdpConfirm { get; init; }
        public string Role { get; init; }
    }
}

