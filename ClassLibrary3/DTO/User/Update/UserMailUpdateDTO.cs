

namespace API_Shop.DTO.User.Update
{
    public record UserMailUpdateDTO
    {
        public UserMailUpdateDTO(string mail)
        {
            Mail = mail;
        }

        public string Mail { get; init; }
    }
}
