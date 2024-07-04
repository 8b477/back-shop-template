using Moq;
using API_Shop.Interfaces;
using API_Shop.Models;
using API_Shop.DTO.Address.Update;
using System.Diagnostics.Metrics;


namespace TestXUnit_Shop.Address_Tests
{
    public class AddressRepositoryTests
    {
        private readonly Mock<IAddressRepository> _mockRepo;
        private readonly List<Address> _addresses;

        public AddressRepositoryTests()
        {
            _mockRepo = new Mock<IAddressRepository>();
            _addresses = new List<Address>
        {
            new Address { Id = 1, StreetNumber = 123, City = "New York", PostalCode = 10001, Country = "USA" },
            new Address { Id = 2, StreetNumber = 456, City = "Los Angeles", PostalCode = 90001, Country = "USA" },
            new Address { Id = 3, StreetNumber = 789, City = "London", PostalCode = 12345, Country = "UK" }
        };

            SetupMockRepository();
        }

        private void SetupMockRepository()
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(_addresses.Cast<Address?>());

            _mockRepo.Setup(repo => repo.GetByPostalCode(It.IsAny<int>()))
                .ReturnsAsync((int postalCode) => _addresses.Where(a => a.PostalCode == postalCode).Cast<Address?>());

            _mockRepo.Setup(repo => repo.GetByCountry(It.IsAny<string>()))
                .ReturnsAsync((string country) => _addresses.Where(a => a.Country == country).Cast<Address?>());

            _mockRepo.Setup(repo => repo.GetByCity(It.IsAny<string>()))
                .ReturnsAsync((string city) => _addresses.Where(a => a.City == city).Cast<Address?>());

            _mockRepo.Setup(repo => repo.Delete(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    var address = _addresses.FirstOrDefault(a => a.Id == id);
                    if (address != null)
                    {
                        _addresses.Remove(address);
                        return true;
                    }
                    return false;
                });

            _mockRepo.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<AddressUpdateDTO>()))
                .ReturnsAsync((int id, AddressUpdateDTO addressUpdate) =>
                {
                    var address = _addresses.FirstOrDefault(a => a.Id == id);
                    if (address != null)
                    {
                        address.StreetNumber = addressUpdate.StreetNumber;
                        address.City = addressUpdate.City;
                        address.PostalCode = addressUpdate.PostalCode;
                        address.Country = addressUpdate.Country;
                        return address;
                    }
                    return null;
                });

            _mockRepo.Setup(repo => repo.Create(It.IsAny<Address>()))
                .ReturnsAsync((Address address) =>
                {
                    address.Id = _addresses.Max(a => a.Id) + 1;
                    _addresses.Add(address);
                    return address;
                });
        }

        [Fact]
        public async Task GetAll_ReturnsAllAddresses()
        {
            var result = await _mockRepo.Object.GetAll();
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetByPostalCode_ReturnsMatchingAddresses()
        {
            var result = await _mockRepo.Object.GetByPostalCode(10001);
            Assert.Single(result);
            Assert.Equal("New York", result.First()?.City);
        }

        [Fact]
        public async Task GetByCountry_ReturnsMatchingAddresses()
        {
            var result = await _mockRepo.Object.GetByCountry("USA");
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByCity_ReturnsMatchingAddresses()
        {
            var result = await _mockRepo.Object.GetByCity("London");
            Assert.Single(result);
            Assert.Equal("UK", result.First()?.Country);
        }

        [Fact]
        public async Task Delete_ExistingAddress_ReturnsTrue()
        {
            var result = await _mockRepo.Object.Delete(1);
            Assert.True(result);
            var allAddresses = await _mockRepo.Object.GetAll();
            Assert.Equal(2, allAddresses.Count());
        }

        [Fact]
        public async Task Delete_NonExistingAddress_ReturnsFalse()
        {
            var result = await _mockRepo.Object.Delete(999);
            Assert.False(result);
        }

        [Fact]
        public async Task Update_ExistingAddress_ReturnsUpdatedAddress()
        {
            var updateDto = new AddressUpdateDTO (1,123,4,"USA","New York");
            var result = await _mockRepo.Object.Update(1, updateDto);
            Assert.NotNull(result);
            Assert.Equal(42, result.StreetNumber);
            Assert.Equal("Updated City", result.City);
        }

        [Fact]
        public async Task Update_NonExistingAddress_ReturnsNull()
        {
            var updateDto = new AddressUpdateDTO(060303030, 42, 4, "USA", "Los Angeles");
            var result = await _mockRepo.Object.Update(999, updateDto);
            Assert.Null(result);
        }

        [Fact]
        public async Task Create_NewAddress_ReturnsCreatedAddress()
        {
            var newAddress = new Address { StreetNumber = 007, City = "New City", PostalCode = 54321, Country = "Canada" };
            var result = await _mockRepo.Object.Create(newAddress);
            Assert.NotNull(result);
            Assert.Equal(4, result.Id);
            var allAddresses = await _mockRepo.Object.GetAll();
            Assert.Equal(4, allAddresses.Count());
        }
    }

}
