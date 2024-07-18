
namespace BLL_Shop.DTO.User.Update
{
    public record UserPseudoUpdateDTO
    {
        public UserPseudoUpdateDTO(string pseudo)
        {
            Pseudo = pseudo;
        }

        public string Pseudo { get; init; }
    }
}
