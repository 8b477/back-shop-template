using Microsoft.EntityFrameworkCore;
using API_Shop.Models;
using API_Shop.DB.Context;

namespace Test_Shop
{

    public class UnitTestUserEndpoints
    {
        [Fact]
        public void ShouldBeReturnAllUsersOfDatabase()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<ShopDB>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;


            //ACT
            using var context = new ShopDB(options);
            
                context.User.Add(new User
                {
                    Pseudo = "Test User",
                    Mail = "testuser@example.com",
                    Mdp = "password"
                });
                context.SaveChanges();
            


            //ASSERT         
            Assert.Equal(1, context.User.Count());
            Assert.Equal("Test User", context.User.Single().Pseudo);
            
        }


    }
}