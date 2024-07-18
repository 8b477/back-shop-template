
namespace BLL_Shop.DTO.User.Update
{
    public record UserPseudoUpdateDTO
    {
        public UserPseudoUpdateDTO(string pseudo)
        {
            Pseudo = pseudo;
        }

        public required string Pseudo { get; init; }
    }
}
