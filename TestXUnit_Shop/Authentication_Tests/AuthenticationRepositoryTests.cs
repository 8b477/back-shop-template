using Moq;
using API_Shop.Interfaces;
using API_Shop.DTO.User.Token;


namespace TestXUnit_Shop.Authentication_Tests
{
    public class AuthenticationRepositoryTests
    {
        private readonly Mock<IAuthenticationRepository> _mockRepo;

        public AuthenticationRepositoryTests()
        {
            _mockRepo = new Mock<IAuthenticationRepository>();
        }

        [Fact]
        public async Task Authentication_ValidCredentials_ReturnsUserToken()
        {
            // Arrange
            string validEmail = "user@example.com";
            string validPassword = "password123";

            var expectedToken = new UserTokenDTO
            {
                Pseudo = "valid pseudo",
                Id = 1,
                Mail = "user@example.com",
                Role = "User"
            };

            _mockRepo.Setup(repo => repo.Authentication(validEmail, validPassword))
                .ReturnsAsync(expectedToken);

            // Act
            var result = await _mockRepo.Object.Authentication(validEmail, validPassword);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedToken.Pseudo, result.Pseudo);
            Assert.Equal(expectedToken.Id, result.Id);
            Assert.Equal(expectedToken.Mail, result.Mail);
        }


        [Fact]
        public async Task Authentication_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            string invalidEmail = "invalid@example.com";
            string invalidPassword = "wrongpassword";

            _mockRepo.Setup(repo => repo.Authentication(invalidEmail, invalidPassword))
                .ReturnsAsync((UserTokenDTO?)null);

            // Act
            var result = await _mockRepo.Object.Authentication(invalidEmail, invalidPassword);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Authentication_EmptyCredentials_ReturnsNull()
        {
            // Arrange
            string emptyEmail = "";
            string emptyPassword = "";

            _mockRepo.Setup(repo => repo.Authentication(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((UserTokenDTO?)null);

            // Act
            var result = await _mockRepo.Object.Authentication(emptyEmail, emptyPassword);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Authentication_NullCredentials_ReturnsNull()
        {
            // Arrange
            string? nullEmail = null;
            string? nullPassword = null;

            _mockRepo.Setup(repo => repo.Authentication(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((UserTokenDTO?)null);

            // Act
            var result = await _mockRepo.Object.Authentication(nullEmail!, nullPassword!);

            // Assert
            Assert.Null(result);
        }
    }
}