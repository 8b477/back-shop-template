using DAL_Shop.DTO.Address;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;
using Moq;

using TestXUnit_Shop.Address_Tests.Mapper;
using TestXUnit_Shop.Mockup_DB;


namespace TestXUnit_Shop.Address_Tests.Repository
{
    public class AddressRepositoryTests
    {
        private readonly Mock<IAddressRepository> _mockRepo;
        private readonly List<Address> _addresses;

        public AddressRepositoryTests()
        {
            _addresses = FakeDB.GetAdressesData();
            _mockRepo = new Mock<IAddressRepository>();
            SetupMockRepository();
        }



        private void SetupMockRepository()
        {
            // CREATE
            _mockRepo.Setup(repo => repo.Create(It.IsAny<Address>()))
                .ReturnsAsync((Address address) => MapperAddress.EntityToDTO(address));

            // GET ALL
            _mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(_addresses);

            // GET BY POSTAL CODE
            _mockRepo.Setup(repo => repo.GetByPostalCode(It.IsAny<int>()))
                .ReturnsAsync((int postalCode) => _addresses.Where(a => a.PostalCode == postalCode).ToList());

            // GET BY COUNTRY
            _mockRepo.Setup(repo => repo.GetByCountry(It.IsAny<string>()))
                .ReturnsAsync((string country) => _addresses.Where(a => a.Country == country).ToList());

            // GET BY CITY
            _mockRepo.Setup(repo => repo.GetByCity(It.IsAny<string>()))
                .ReturnsAsync((string city) => _addresses.Where(a => a.City == city).ToList());

            // UPDATE
            _mockRepo.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<Address>()))
                .ReturnsAsync((int id, Address address) =>
                {
                    var existingAddress = _addresses.FirstOrDefault(a => a.Id == id);
                    if (existingAddress != null)
                    {
                        existingAddress.PostalCode = address.PostalCode;
                        existingAddress.StreetNumber = address.StreetNumber;
                        existingAddress.StreetName = address.StreetName;
                        existingAddress.Country = address.Country;
                        existingAddress.City = address.City;
                        existingAddress.PhoneNumber = address.PhoneNumber;
                        return existingAddress;
                    }
                    return null;
                });

            // UPDATE CITY
            _mockRepo.Setup(repo => repo.UpdateCity(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync((int id, int postalCode, int streetNumber, string city) =>
                {
                    var existingAddress = _addresses.FirstOrDefault(a => a.Id == id);
                    if (existingAddress != null)
                    {
                        existingAddress.PostalCode = postalCode;
                        existingAddress.StreetNumber = streetNumber;
                        existingAddress.City = city;
                        return existingAddress;
                    }
                    return null;
                });

            // UPDATE PHONE NUMBER
            _mockRepo.Setup(repo => repo.UpdatePhoneNumber(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync((int id, string phoneNumber) =>
                {
                    var existingAddress = _addresses.FirstOrDefault(a => a.Id == id);
                    if (existingAddress != null)
                    {
                        existingAddress.PhoneNumber = phoneNumber;
                        return existingAddress;
                    }
                    return null;
                });

            // DELETE
            _mockRepo.Setup(repo => repo.Delete(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    var addressToRemove = _addresses.FirstOrDefault(a => a.Id == id);
                    if (addressToRemove != null)
                    {
                        _addresses.Remove(addressToRemove);
                        return true;
                    }
                    return false;
                });

            // CHECK IF USER HAS AN ADDRESS
            _mockRepo.Setup(repo => repo.CheckIfUserAlreadyHasAddress(It.IsAny<int>()))
                .ReturnsAsync((int userId) => _addresses.Any(a => a.UserId == userId));
        }



        #region CREATE

        [Fact]
        public async Task Create_ShouldReturnAddressViewDTO()
        {
            // Arrange
            var newAddress = new Address { Id = 4, UserId = 4, PostalCode = 11111, StreetNumber = 4, StreetName = "New St", Country = "Canada", City = "Toronto", PhoneNumber = "1231231234" };

            // Act
            var result = await _mockRepo.Object.Create(newAddress);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AddressViewDTO>(result);
            Assert.Equal(newAddress.Id, result.Id);
            Assert.Equal(newAddress.UserId, result.UserId);
            Assert.Equal(newAddress.PostalCode, result.PostalCode);
            Assert.Equal(newAddress.StreetNumber, result.StreetNumber);
            Assert.Equal(newAddress.StreetName, result.StreetName);
            Assert.Equal(newAddress.Country, result.Country);
            Assert.Equal(newAddress.City, result.City);
            Assert.Equal(newAddress.PhoneNumber, result.PhoneNumber);
        }

        #endregion



        #region GET

        [Fact]
        public async Task GetAll_ShouldReturnAllAddresses()
        {
            // Act
            var result = await _mockRepo.Object.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_addresses.Count, result.Count);
        }

        [Theory]
        [InlineData(12345, 1)]
        [InlineData(54321, 1)]
        [InlineData(99995, 0)]
        public async Task GetByPostalCode_ShouldReturnMatchingAddresses(int postalCode, int expectedCount)
        {
            // Act
            var result = await _mockRepo.Object.GetByPostalCode(postalCode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);

            if (expectedCount > 0)
            {
                Assert.All(result, address =>
                {
                    Assert.NotNull(address);
                    Assert.Equal(postalCode, address.PostalCode);
                });
            }
        }

        [Theory]
        [InlineData("USA", 2)]
        [InlineData("UK", 1)]
        [InlineData("Canada", 0)]
        public async Task GetByCountry_ShouldReturnMatchingAddresses(string country, int expectedCount)
        {
            // Act
            var result = await _mockRepo.Object.GetByCountry(country);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);

            if (expectedCount > 0)
            {
                Assert.All(result, address =>
                {
                    Assert.NotNull(address);
                    Assert.Equal(country, address.Country);
                });
            }

        }

        [Theory]
        [InlineData("New York", 2)]
        [InlineData("Los Angeles", 1)]
        [InlineData("Paris", 0)]
        public async Task GetByCity_ShouldReturnMatchingAddresses(string city, int expectedCount)
        {
            // Act
            var result = await _mockRepo.Object.GetByCity(city);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);

            if (expectedCount > 0)
            {
                Assert.All(result, address =>
                {
                    Assert.NotNull(address);
                    Assert.Equal(city, address.City);
                });
            }
        }

        #endregion


        #region UPDATE

        [Fact]
        public async Task Update_ShouldReturnUpdatedAddress()
        {
            // Arrange
            var updatedAddress = new Address { Id = 1, UserId = 1, PostalCode = 54321, StreetNumber = 10, StreetName = "Updated St", Country = "Canada", City = "Vancouver", PhoneNumber = "9876543210" };

            // Act
            var result = await _mockRepo.Object.Update(1, updatedAddress);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedAddress.PostalCode, result.PostalCode);
            Assert.Equal(updatedAddress.StreetNumber, result.StreetNumber);
            Assert.Equal(updatedAddress.StreetName, result.StreetName);
            Assert.Equal(updatedAddress.Country, result.Country);
            Assert.Equal(updatedAddress.City, result.City);
            Assert.Equal(updatedAddress.PhoneNumber, result.PhoneNumber);
        }

        [Fact]
        public async Task Update_ShouldReturnNullForNonExistentAddress()
        {
            // Arrange
            var updatedAddress = new Address { Id = 99, UserId = 99, PostalCode = 99999, StreetNumber = 99, StreetName = "Nonexistent St", Country = "Nowhere", City = "Ghost Town", PhoneNumber = "9999999999" };

            // Act
            var result = await _mockRepo.Object.Update(99, updatedAddress);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateCity_ShouldReturnUpdatedAddress()
        {
            // Arrange
            int id = 1;
            int postalCode = 54321;
            int streetNumber = 10;
            string city = "Updated City";

            // Act
            var result = await _mockRepo.Object.UpdateCity(id, postalCode, streetNumber, city);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(postalCode, result.PostalCode);
            Assert.Equal(streetNumber, result.StreetNumber);
            Assert.Equal(city, result.City);
        }

        [Fact]
        public async Task UpdateCity_ShouldReturnNullForNonExistentAddress()
        {
            // Act
            var result = await _mockRepo.Object.UpdateCity(99, 99999, 99, "Nonexistent City");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdatePhoneNumber_ShouldReturnUpdatedAddress()
        {
            // Arrange
            int id = 1;
            string phoneNumber = "1112223333";

            // Act
            var result = await _mockRepo.Object.UpdatePhoneNumber(id, phoneNumber);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(phoneNumber, result.PhoneNumber);
        }

        [Fact]
        public async Task UpdatePhoneNumber_ShouldReturnNullForNonExistentAddress()
        {
            // Act
            var result = await _mockRepo.Object.UpdatePhoneNumber(99, "9999999999");

            // Assert
            Assert.Null(result);
        }

        #endregion



        #region DELETE

        [Fact]
        public async Task Delete_ShouldReturnTrueForExistingAddress()
        {
            // Act
            var result = await _mockRepo.Object.Delete(1);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(_addresses, a => a.Id == 1);
        }

        [Fact]
        public async Task Delete_ShouldReturnFalseForNonExistentAddress()
        {
            // Act
            var result = await _mockRepo.Object.Delete(99);

            // Assert
            Assert.False(result);
        }

        #endregion



        #region TOOLS

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, false)]
        [InlineData(4, true)]
        public async Task CheckIfUserAlreadyHasAddress_ShouldReturnExpectedResult(int userId, bool expected)
        {
            // Act
            var result = await _mockRepo.Object.CheckIfUserAlreadyHasAddress(userId);

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion


    }
}

