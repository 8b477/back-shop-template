using Database_Shop.Entity;


namespace TestXUnit_Shop.Mockup_DB
{
    internal static class FakeDB
    {
        internal static List<User> getUsersData()
        {

            List<Address> adresses = new List<Address>
            {
                new Address { Id = 1, UserId = 4, City = "Couvin", Country = "Belgique", StreetName = "rue du fou", StreetNumber = 40, PhoneNumber = "0603030", PostalCode = 5670 },
                new Address { Id = 2, UserId = 5, City = "Nismes", Country = "Belgique", StreetName = "rue longue", StreetNumber = 4, PhoneNumber = "0606060", PostalCode = 5000 },
                new Address { Id = 3, UserId = 6, City = "Paris", Country = "France", StreetName = "rue de la tour", StreetNumber = 100, PhoneNumber = "0715224", PostalCode = 12000 }
            };

            return new List<User>
            {
                new User { Id = 1, Pseudo = "John", Mail = "john@example.com", Mdp = "Test1234*", Address = null, Orders = null, Role = "User" },
                new User { Id = 2, Pseudo = "Jane", Mail = "jane@example.com", Mdp = "Test1234*", Address = null, Orders = null, Role = "User" },
                new User { Id = 3, Pseudo = "Bob", Mail = "bob@example.com", Mdp = "Test1234*", Address = null, Orders = null, Role = "User" },
                new User { Id = 4, Pseudo = "Lily", Mail = "lily@example.com", Mdp = "Test1234*", Address = adresses[0], Orders = null, Role = "User" },
                new User { Id = 5, Pseudo = "Marie", Mail = "marie@example.com", Mdp = "Test1235*", Address = adresses[1], Orders = null, Role = "User" },
                new User { Id = 6, Pseudo = "Céline", Mail = "celine@example.com", Mdp = "Test1236*", Address = adresses[2], Orders = null, Role = "Admin" }
            };
        }
    }
}
