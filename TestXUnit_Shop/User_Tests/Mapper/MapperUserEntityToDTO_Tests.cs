using Database_Shop.Entity;
using TestXUnit_Shop.Mockup_DB;


namespace TestXUnit_Shop.User_Tests.Mapper
{
    public class MapperUserEntityToDTO_Tests
    {
        private readonly List<User> _users;

        public MapperUserEntityToDTO_Tests()
        {
            // Initialize Users
            _users = FakeDB.getUsersData();
        }


        [Fact]
        private void Test_User_To_UserViewDTO()
        {
            // Act
            var listEntityUser = _users.ToList(); // Original list
            var listUserViewDTO = MapperUser.EntityToDTO(listEntityUser); // Mapped list

            // Assert
            Assert.NotNull(listEntityUser);
            Assert.NotNull(listUserViewDTO);
            Assert.Equal(listEntityUser.Count, listUserViewDTO.Count);

            foreach (var userViewDTO in listUserViewDTO)
            {
                var correspondingUser = listEntityUser.FirstOrDefault(u => u.Id == userViewDTO.Id);

                Assert.NotNull(correspondingUser);
                Assert.Equal(correspondingUser.Id, userViewDTO.Id);
                Assert.Equal(correspondingUser.Pseudo, userViewDTO.Pseudo);
                Assert.Equal(correspondingUser.Mail, userViewDTO.Mail);
                Assert.Equal(correspondingUser.Role, userViewDTO.Role);

                if (correspondingUser.Address != null)
                {
                    Assert.NotNull(userViewDTO.Address);
                    Assert.Equal(correspondingUser.Address.Id, userViewDTO.Address.Id);
                    Assert.Equal(correspondingUser.Address.UserId, userViewDTO.Address.UserId);
                    Assert.Equal(correspondingUser.Address.PostalCode, userViewDTO.Address.PostalCode);
                    Assert.Equal(correspondingUser.Address.StreetNumber, userViewDTO.Address.StreetNumber);
                    Assert.Equal(correspondingUser.Address.StreetName, userViewDTO.Address.StreetName);
                    Assert.Equal(correspondingUser.Address.Country, userViewDTO.Address.Country);
                    Assert.Equal(correspondingUser.Address.City, userViewDTO.Address.City);
                    Assert.Equal(correspondingUser.Address.PhoneNumber, userViewDTO.Address.PhoneNumber);
                }
                else
                {
                    Assert.Null(userViewDTO.Address);
                }
            }
        }
    }
}
