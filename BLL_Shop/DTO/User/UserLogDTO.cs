namespace BLL_Shop.DTO.User
{
    public record UserLogDto
    {
        public UserLogDto(string mail, string mdp)
        {
            Mail = mail;
            Mdp = mdp;
        }

        public required string Mail { get; init; }
        public required string Mdp { get; init; }
    }
}
