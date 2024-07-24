using DAL_Shop.DTO.Address;
using Database_Shop.Entity;

using TestXUnit_Shop.Mockup_DB;


namespace TestXUnit_Shop.Address_Tests.Mapper
{
    public class MapperAddressEntityToDTO
    {
        private readonly List<Address> _addresses;

        public MapperAddressEntityToDTO()
        {
            _addresses = FakeDB.GetAdressesData();
        }


        [Fact]
        public void Test_Address_To_AddressViewDTO()
        {
            List<Address> addresses = _addresses;
            List<AddressViewDTO> addressViewDTOs = MapperAddress.EntityToDTO(addresses);

            Address ad = addresses[0];
            AddressViewDTO dto = MapperAddress.EntityToDTO(ad);

            Assert.NotNull(addressViewDTOs);
            Assert.NotNull(addresses);
            Assert.NotNull(ad);
            Assert.NotNull(dto);

            Assert.Equal(addressViewDTOs.Count, addresses.Count);

            Assert.Equal(ad.Id, dto.Id);
            Assert.Equal(ad.UserId, dto.UserId);
            Assert.Equal(ad.Country, dto.Country);
            Assert.Equal(ad.City, dto.City);
            Assert.Equal(ad.PhoneNumber, dto.PhoneNumber);
            Assert.Equal(ad.StreetName, dto.StreetName);
            Assert.Equal(ad.StreetNumber, dto.StreetNumber);
        }
    }
}
