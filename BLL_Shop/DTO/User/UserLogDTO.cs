namespace BLL_Shop.DTO.User
{
    public record UserLogDto
    {
        public UserLogDto(string mail, string mdp)
        {
            Mail = mail;
            Mdp = mdp;
        }

        public string Mail { get; init; }
        public string Mdp { get; init; }
    }
}
