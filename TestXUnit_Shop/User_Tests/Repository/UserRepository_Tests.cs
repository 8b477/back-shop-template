using DAL_Shop.DTO.User;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;
using DAL_Shop.DTO.Address;
using TestXUnit_Shop.Mockup_DB;
using TestXUnit_Shop.User_Tests.Mapper;

using Moq;


namespace TestXUnit_Shop.User_Tests.Repository
{
    public class UserRepository_Tests
    {

#region -------> DI
        private readonly List<User> _users;
        private readonly Mock<IUserRepository> _mockRepo;

        public UserRepository_Tests()
        {
            _users = FakeDB.getUsersData();
            _mockRepo = CreateMockUserRepository();
        } 
#endregion


#region -------> Init Mockup
        private Mock<IUserRepository> CreateMockUserRepository()
        {
            var mockRepo = new Mock<IUserRepository>();


            mockRepo.Setup(repo => repo.Create(It.IsAny<User>()))
                .Callback<User>(user =>
                {
                    user.Id = _users.Count + 1;
                    _users.Add(user);
                }).ReturnsAsync((User user) => user);


            mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(() =>
                {
                    return MapperUser.EntityToDTO(_users);
                });


            mockRepo.Setup(repo => repo.GetByID(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    var u = _users.FirstOrDefault(u => u.Id == id);

                    if (u is null)
                        return null;

                    return new UserViewDTO(
                        u.Id,
                        u.Pseudo,
                        u.Mail,
                        u.Role,
                        u.Address is null
                        ? null
                        : new AddressViewDTO(
                            u.Address.Id,
                            u.Address.UserId,
                            u.Address.PostalCode,
                            u.Address.StreetNumber,
                            u.Address.StreetName,
                            u.Address.Country,
                            u.Address.City,
                            u.Address.PhoneNumber
                        )
                    );
                });


            mockRepo.Setup(repo => repo.GetByPseudo(It.IsAny<string>()))
                .ReturnsAsync((string pseudo) =>
                {
                    List<User> result = _users.FindAll(u => u.Pseudo.ToUpper() == pseudo.ToUpper());

                    return MapperUser.EntityToDTO(result);
                });

            mockRepo.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<User>()))
                .ReturnsAsync((string message) => message);

            return mockRepo;
        } 
#endregion


#region -------> CREATE
        [Fact]
        public async void Create_Add_User()
        {
            // Arrange
            var newUser = new User
            {
                Id = _users.Count + 1,
                Pseudo = "Lily",
                Mail = "lily@mail.be",
                Mdp = "Test1234*",
                MdpConfirm = "Test1234*",
                Role = "User"
            };

            // Act
            var result = await _mockRepo.Object.Create(newUser);

            // Assert
            Assert.NotNull(result);

            Assert.Null(result.Address);
            Assert.Null(result.Orders);

            Assert.Equal(newUser.Id, result.Id);
            Assert.Equal(newUser.Pseudo, result.Pseudo);
            Assert.Equal(newUser.Mail, result.Mail);
            Assert.Equal(newUser.Mdp, result.Mdp);
            Assert.Equal(newUser.Role, result.Role);
        }
#endregion



#region -------> GET

        #region GET ALL
        [Fact]
        public async Task Get_All_User()
        {
            // Act
            var result = await _mockRepo.Object.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_users.Count, result.Count);
        }
        #endregion


        #region GET BY ID
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task Get_One_User_By_Id(int id)
        {
            // Arrange
            var correspondingUser = _users.FirstOrDefault(u => u.Id == id);

            // Act
            var result = await _mockRepo.Object.GetByID(id);

            //Assert
            Assert.NotNull(correspondingUser);
            Assert.NotNull(result);

            Assert.Equal(correspondingUser.Id, result.Id);
            Assert.Equal(correspondingUser.Pseudo, result.Pseudo);
            Assert.Equal(correspondingUser.Mail, result.Mail);
            Assert.Equal(correspondingUser.Role, result.Role);


            if (correspondingUser.Address != null)
            {
                Assert.NotNull(result.Address);
                Assert.NotNull(correspondingUser.Address);

                Assert.Equal(correspondingUser.Address.Id, result.Address.Id);
                Assert.Equal(correspondingUser.Address.UserId, result.Address.UserId);
                Assert.Equal(correspondingUser.Address.PostalCode, result.Address.PostalCode);
                Assert.Equal(correspondingUser.Address.StreetNumber, result.Address.StreetNumber);
                Assert.Equal(correspondingUser.Address.StreetName, result.Address.StreetName);
                Assert.Equal(correspondingUser.Address.Country, result.Address.Country);
                Assert.Equal(correspondingUser.Address.City, result.Address.City);
                Assert.Equal(correspondingUser.Address.PhoneNumber, result.Address.PhoneNumber);
            }
            else
            {
                Assert.Null(result.Address);
                Assert.Null(correspondingUser.Address);
            }
        }
        #endregion


        #region GET BY PSEUDO
        [Theory]
        [InlineData("John")]
        [InlineData("Jane")]
        [InlineData("Bob")]
        [InlineData("Lily")]
        [InlineData("MARIE")] // Full Maj
        [InlineData("john")] // Full Min
        public async Task Get_User_By_Pseudo(string pseudo)
        {
            var result = await _mockRepo.Object.GetByPseudo(pseudo);

            Assert.NotNull(result);

            if (result is List<UserViewDTO> userList)
            {
                foreach (UserViewDTO u in userList)
                {
                    var correspondingUser = _users.FirstOrDefault(user => user.Id == u.Id);

                    Assert.NotNull(correspondingUser);

                    Assert.Equal(u.Id, correspondingUser.Id);
                    Assert.Equal(u.Pseudo, correspondingUser.Pseudo);
                    Assert.Equal(u.Mail, correspondingUser.Mail);

                    if (u.Address is not null)
                    {
                        Assert.NotNull(correspondingUser.Address);
                        Assert.NotNull(u.Address);

                        Assert.Equal(u.Address.Id, correspondingUser.Address.Id);
                        Assert.Equal(u.Address.UserId, correspondingUser.Address.UserId);
                        Assert.Equal(u.Address.StreetNumber, correspondingUser.Address.StreetNumber);
                        Assert.Equal(u.Address.StreetName, correspondingUser.Address.StreetName);
                        Assert.Equal(u.Address.Country, correspondingUser.Address.Country);
                        Assert.Equal(u.Address.City, correspondingUser.Address.City);
                        Assert.Equal(u.Address.PostalCode, correspondingUser.Address.PostalCode);
                        Assert.Equal(u.Address.PhoneNumber, correspondingUser.Address.PhoneNumber);
                    }
                }
            }
            else if (result is UserViewDTO u)
            {
                var correspondingUser = _users.FirstOrDefault(user => user.Id == u.Id);

                Assert.NotNull(correspondingUser);
                Assert.NotNull(u);

                Assert.Equal(u.Id, correspondingUser.Id);
                Assert.Equal(u.Pseudo, correspondingUser.Pseudo);
                Assert.Equal(u.Mail, correspondingUser.Mail);

                if (u.Address is not null)
                {
                    Assert.NotNull(correspondingUser.Address);
                    Assert.NotNull(u.Address);

                    Assert.Equal(u.Address.Id, correspondingUser.Address.Id);
                    Assert.Equal(u.Address.UserId, correspondingUser.Address.UserId);
                    Assert.Equal(u.Address.StreetNumber, correspondingUser.Address.StreetNumber);
                    Assert.Equal(u.Address.StreetName, correspondingUser.Address.StreetName);
                    Assert.Equal(u.Address.Country, correspondingUser.Address.Country);
                    Assert.Equal(u.Address.City, correspondingUser.Address.City);
                    Assert.Equal(u.Address.PostalCode, correspondingUser.Address.PostalCode);
                    Assert.Equal(u.Address.PhoneNumber, correspondingUser.Address.PhoneNumber);
                }
            }
        } 
        #endregion

#endregion

    }
}