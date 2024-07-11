
using DAL_Shop.DTO.Address;

namespace DAL_Shop.DTO.User
{
    public record UserViewDTO
    {
        public UserViewDTO(int id, string pseudo, string mail, string role, AddressViewDTO address)
        {
            Id = id;
            Pseudo = pseudo;
            Mail = mail;
            Role = role;
            Address = address;
        }

        public int Id { get; init; }
        public string Pseudo { get; init; }
        public string Mail { get; init; }
        public string Role { get; init; }
        public AddressViewDTO? Address { get; init; }
    }
}
