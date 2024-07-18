

namespace BLL_Shop.DTO.User.Update
{
    public record UserMailUpdateDTO
    {
        public UserMailUpdateDTO(string mail)
        {
            Mail = mail;
        }

        public required string Mail { get; init; }
    }
}
