namespace API_Shop.DTO.User.Token
{
    public record UserTokenDTO
    {
        public UserTokenDTO(int id, string pseudo, string mail, string role)
        {
            Id = id;
            Pseudo = pseudo;
            Mail = mail;
            Role = role;
        }

        public int Id { get; init; }
        public string Pseudo { get; init; }
        public string Mail { get; init; }
        public string Role { get; init; }
    }

}
