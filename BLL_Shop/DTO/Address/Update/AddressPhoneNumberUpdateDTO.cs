
namespace BLL_Shop.DTO.Address.Update
{
    public record AddressPhoneNumberUpdateDTO
    {
        public AddressPhoneNumberUpdateDTO(int phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public required int PhoneNumber { get; init; }
    }
}
