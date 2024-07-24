
namespace BLL_Shop.DTO.Address.Update
{
    public record AddressPhoneNumberUpdateDTO
    {
        public AddressPhoneNumberUpdateDTO(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; init; }
    }
}
