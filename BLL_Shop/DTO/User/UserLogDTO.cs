namespace BLL_Shop.DTO.User
{
    public record UserLogDto
    {
        public UserLogDto(string mail, string pwd)
        {
            Mail = mail;
            Pwd = pwd;
        }

        public string Mail { get; init; }
        public string Pwd { get; init; }
    }
}
