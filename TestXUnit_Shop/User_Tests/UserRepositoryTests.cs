using DAL_Shop.DTO.User;
using DAL_Shop.Interfaces;
using Database_Shop.Entity;

using Moq;

namespace TestXUnit_Shop.User_Tests
{
    public class UserRepositoryTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly List<User> _users;

        public UserRepositoryTests()
        {
            _users = new List<User>
            {
                new User { Id = 1, Pseudo = "John", Mail = "john@example.com" },
                new User { Id = 2, Pseudo = "Jane", Mail = "jane@example.com" },
                new User { Id = 3, Pseudo = "Bob", Mail = "bob@example.com" }
            };

            _mockRepo = CreateMockUserRepository();
        }

        private Mock<IUserRepository> CreateMockUserRepository()
        {
            var mockRepo = new Mock<IUserRepository>();

            //mockRepo.Setup(repo => repo.GetAll())
            //    .ReturnsAsync(() => _users.Cast<User>());

            mockRepo.Setup(repo => repo.GetAll()).Returns(() => _users.Cast<List<UserViewDTO>>());

            mockRepo.Setup(repo => repo.GetByID(It.IsAny<int>()))
                .ReturnsAsync((int id) => _users.FirstOrDefault(u => u.Id == id));

            mockRepo.Setup(repo => repo.GetByPseudo(It.IsAny<string>()))
                .ReturnsAsync((string pseudo) => _users.Where(u => u.Pseudo.Contains(pseudo)).Cast<User?>());

            mockRepo.Setup(repo => repo.Create(It.IsAny<User>()))
                .Callback<User>(user =>
                {
                    user.Id = _users.Max(u => u.Id) + 1;
                    _users.Add(user);
                })
                .ReturnsAsync((User user) => user);

            mockRepo.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<User>()))
                .ReturnsAsync((int id, string response, User userToAdd) =>
                {
                    var user = _users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                        user.Pseudo = userToAdd.Pseudo ?? user.Pseudo;
                        user.Mail = userToAdd.Mail ?? user.Mail;
                        return "Update success";
                    }
                    return "";
                });

            mockRepo.Setup(repo => repo.Delete(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    var user = _users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                        _users.Remove(user);
                        return true;
                    }
                    return false;
                });

            return mockRepo;
        }


        [Fact]
        public async Task GetAll_ReturnsAllUsers()
        {
            var result = await _mockRepo.Object.GetAll();
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetByID_ReturnsCorrectUser()
        {
            var result = await _mockRepo.Object.GetByID(1);
            Assert.NotNull(result);
            Assert.Equal("John", result.Pseudo);
        }

        [Fact]
        public async Task GetByPseudo_ReturnsMatchingUsers()
        {
            var result = await _mockRepo.Object.GetByPseudo("Jo");
            Assert.Single(result);
            Assert.Equal("John", result.First()?.Pseudo);
        }

        [Fact]
        public async Task Create_AddsNewUser()
        {
            var newUser = new User { Pseudo = "Alice", Mail = "alice@example.com" };
            var result = await _mockRepo.Object.Create(newUser);
            Assert.NotNull(result);
            Assert.Equal(4, result.Id);
        }

        [Fact]
        public async Task Update_ModifiesExistingUser()
        {
            var updateDto = new User { Id = 1, Pseudo = "John", Mail = "john@example.com" };
            var result = await _mockRepo.Object.Update(2, updateDto);
            Assert.NotNull(result);
            Assert.Equal("Jane Updated", result);
        }

        [Fact]
        public async Task Delete_RemovesUser()
        {
            var result = await _mockRepo.Object.Delete(3);
            Assert.True(result);
            var allUsers = await _mockRepo.Object.GetAll();
            Assert.Equal(2, allUsers.Count());
        }
    }
}