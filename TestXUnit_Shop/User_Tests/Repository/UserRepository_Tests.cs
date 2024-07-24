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
        private readonly List<User> _users;
        private readonly Mock<IUserRepository> _mockRepo;

        public UserRepository_Tests()
        {
            _users = FakeDB.GetUsersData();
            _mockRepo = CreateMockUserRepository();
        } 

        private Mock<IUserRepository> CreateMockUserRepository()
        {
            var mockRepo = new Mock<IUserRepository>();

            // CREATE
            mockRepo.Setup(repo => repo.Create(It.IsAny<User>()))
                .Callback<User>(user =>
                {
                    user.Id = _users.Count + 1;
                    _users.Add(user);
                }).ReturnsAsync((User user) => user);

            // GET ALL
            mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(() =>
                {
                    return MapperUser.EntityToDTO(_users);
                });

            // GET BY ID
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

            // GET BY PSEUDO
            mockRepo.Setup(repo => repo.GetByPseudo(It.IsAny<string>()))
                .ReturnsAsync((string pseudo) =>
                {
                    List<User> result = _users.FindAll(u => u.Pseudo.ToUpper() == pseudo.ToUpper());

                    return MapperUser.EntityToDTO(result);
                });

            // UPDATE
            mockRepo.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<User>()))
                .ReturnsAsync((int idUser, User userToAdd) =>
                {
                    User? correspondingUser = _users.FirstOrDefault(u => u.Id == idUser);

                    if (correspondingUser is null)
                        return "";

                    return "User update !";
                });

            // UPDATE MAIL
            mockRepo.Setup(repo => repo.UpdateMail(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync((int idUser, string mail) =>
                {
                    User? result = _users.FirstOrDefault(u => u.Id == idUser);

                    if (result is null)
                        return "";

                    result.Mail = mail;

                    return "Mail update !";
                });

            // UPDATE PSEUDO
            mockRepo.Setup(repo => repo.UpdatePseudo(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync((int idUser, string pseudo) =>
                {
                    User? result = _users.FirstOrDefault(u => u.Id == idUser);

                    if (result is null)
                        return "";

                    result.Pseudo = pseudo;

                    return "Pseudo update !";
                });

            // UPDATE PASSWORD
            mockRepo.Setup(repo => repo.UpdatePwd(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync((int idUser, string pwd) =>
                {
                    User? result = _users.FirstOrDefault(u => u.Id == idUser);

                    if (result is null)
                        return "";

                    result.Mdp = pwd;

                    return "Pwd update !";
                });

            // DELETE
            mockRepo.Setup(repo => repo.Delete(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    User? correspondingUser = _users.FirstOrDefault(u => u.Id == id);

                    if (correspondingUser is null)
                        return false;

                    _users.Remove(correspondingUser);
                    return true;
                });

            // CHECK MAIL
            mockRepo.Setup(repo => repo.IsValidMail(It.IsAny<string>()))
                .ReturnsAsync((string mail) =>
                {
                    User? result = _users.FirstOrDefault(user => user.Mail == mail);

                    if (result is null)
                        return true;

                    return false;
                });

            return mockRepo;
        }


        private User GetModelUser()
        {
            return new()
            {
                Pseudo = "NewUser",
                Mail = "newUser@mail.be",
                Mdp = "Test1234*",
                MdpConfirm = "Test1234*",
                Role = "User"
            };
        }



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
            Assert.IsType<User>(result);
            Assert.Equal(newUser.Id, result.Id);
            Assert.Equal(newUser.Pseudo, result.Pseudo);
            Assert.Equal(newUser.Mail, result.Mail);
            Assert.Equal(newUser.Mdp, result.Mdp);
            Assert.Equal(newUser.Role, result.Role);
        }

    #endregion



    #region -------> GET


        [Fact]
        public async Task Get_All_User()
        {
            // Act
            var result = await _mockRepo.Object.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserViewDTO>(result);
            Assert.Equal(_users.Count, result.Count);
        }



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

            Assert.IsType<User>(correspondingUser);
            Assert.IsType<UserViewDTO>(result);

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
            Assert.IsType<UserViewDTO>(result);

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



    #region -------> UPDATE

        [Fact]
        public async Task Update_User_Returns_Success_Message()
        {
            // Arrange
            int idUser = 1;
            string messageExpected = "User update !";
            User userToAdd = GetModelUser();

            //Act
            string result = await _mockRepo.Object.Update(idUser, userToAdd);


            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.ToString());
            Assert.Contains(messageExpected, result.ToString());
        }


        [Fact]
        public async Task Update_User_Returns_Empty_String_When_User_Not_Found()
        {
            // Arrange
            int idUser = 0;
            string messageExpected = "";
            User userToAdd = GetModelUser();

            //Act
            string result = await _mockRepo.Object.Update(idUser, userToAdd);


            //Assert
            Assert.Empty(result.ToString());
            Assert.Contains(messageExpected, result.ToString());
        }



        [Fact]
        public async Task Update_Mail_User_Returns_Success_Message_String()
        {
            // Arrange
            int idUser = 1;
            string messageExpected = "Mail update !";
            string newMail = "mailUp@mail.be";

            //Act
            string result = await _mockRepo.Object.UpdateMail(idUser, newMail);


            //Assert
            Assert.NotEmpty(result.ToString());
            Assert.NotNull(result.ToString());
            Assert.Contains(messageExpected, result.ToString());
        }


        [Fact]
        public async Task Update_Mail_User_Returns_Empty_Message_String()
        {
            // Arrange
            int idUser = 0;
            string messageExpected = "";
            string newMail = "mailUp@mail.be";

            //Act
            string result = await _mockRepo.Object.UpdateMail(idUser, newMail);


            //Assert
            Assert.Empty(result.ToString());
            Assert.Contains(messageExpected, result.ToString());
        }



        [Fact]
        public async Task Update_Pseudo_User_Returns_Success_Message_String()
        {
            // Arrange
            int idUser = 1;
            string messageExpected = "Pseudo update !";
            string pseudo = "new pseudo";

            //Act
            string result = await _mockRepo.Object.UpdatePseudo(idUser, pseudo);


            //Assert
            Assert.NotEmpty(result.ToString());
            Assert.NotNull(result.ToString());
            Assert.Contains(messageExpected, result.ToString());
        }


        [Fact]
        public async Task Update_Pseudo_User_Returns_Empty_Message_String()
        {
            // Arrange
            int idUser = 0;
            string messageExpected = "";
            string pseudo = "new pseudo";

            //Act
            string result = await _mockRepo.Object.UpdatePseudo(idUser, pseudo);


            //Assert
            Assert.Empty(result.ToString());
            Assert.Contains(messageExpected, result.ToString());
        }



        [Fact]
        public async Task Update_Password_User_Returns_Empty_Message_String()
        {
            // Arrange
            int idUser = 0;
            string messageExpected = "";
            string newMdp = "1234Test*";

            //Act
            string result = await _mockRepo.Object.UpdatePwd(idUser, newMdp);


            //Assert
            Assert.Empty(result.ToString());
            Assert.Contains(messageExpected, result.ToString());
        }


        [Fact]
        public async Task Update_Password_User_Returns_Success_Message_String()
        {
            // Arrange
            int idUser = 1;
            string messageExpected = "Pwd update !";
            string newMdp = "1234Test*";

            //Act
            string result = await _mockRepo.Object.UpdatePwd(idUser, newMdp);


            //Assert
            Assert.NotEmpty(result.ToString());
            Assert.Contains(messageExpected, result.ToString());
        }

    #endregion



    #region -------> DELETE

        [Fact]
        public async Task Delete_User_By_ID_Returns_True()
        {
            int idUser = 1;

            int totalUsersBeforeDelete = _users.Count;

            User? user = _users.FirstOrDefault(u => u.Id == idUser);

            var result = await _mockRepo.Object.Delete(idUser);

            int totalUsersAfterDelete = _users.Count;

            Assert.True(result);
            Assert.NotEqual(totalUsersBeforeDelete,totalUsersAfterDelete);
            Assert.DoesNotContain(user,_users);
            Assert.Null(_users.FirstOrDefault(u => u.Id == idUser));
        }


        [Fact]
        public async Task Delete_User_By_ID_Returns_False()
        {
            int idUser = 0;

            int totalUsersBeforeDelete = _users.Count;

            User? user = _users.FirstOrDefault(u => u.Id == idUser);

            var result = await _mockRepo.Object.Delete(idUser);

            int totalUsersAfterDelete = _users.Count;

            Assert.False(result);
            Assert.Equal(totalUsersBeforeDelete, totalUsersAfterDelete);
        }

    #endregion



    #region  -------> Tools

        [Fact]
        public async Task Check_Whether_Mail_Is_Already_In_Database_If_Is_It_Return_False()
        {
            string mailToCheck = "john@example.com";

            bool result = await _mockRepo.Object.IsValidMail(mailToCheck);

            Assert.False(result);
        }


        [Fact]
        public async Task Check_Whether_Mail_Is_Already_In_Database_If_Is_It_Return_True()
        {
            string mailToCheck = "fake@example.com";

            bool result = await _mockRepo.Object.IsValidMail(mailToCheck);

            Assert.True(result);
        }

    #endregion



    }
}