
namespace BLL_Shop.DTO.Address.Update
{
    public record AddressPhoneNumberUpdateDTO
    {
        public AddressPhoneNumberUpdateDTO(int phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public int PhoneNumber { get; init; }
    }
}
