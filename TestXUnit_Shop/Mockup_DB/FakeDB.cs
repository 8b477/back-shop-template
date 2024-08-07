﻿using Database_Shop.Entity;


namespace TestXUnit_Shop.Mockup_DB
{
    internal static class FakeDB
    {

        internal static List<User> GetUsersData()
        {

            List<Address> adresses = new List<Address>
            {
                new Address { Id = 1, UserId = 4, City = "Couvin", Country = "Belgique", StreetName = "rue du fou", StreetNumber = 40, PhoneNumber = "0603030", PostalCode = 5670 },
                new Address { Id = 2, UserId = 5, City = "Nismes", Country = "Belgique", StreetName = "rue longue", StreetNumber = 4, PhoneNumber = "0606060", PostalCode = 5000 },
                new Address { Id = 3, UserId = 6, City = "Paris", Country = "France", StreetName = "rue de la tour", StreetNumber = 100, PhoneNumber = "0715224", PostalCode = 12000 }
            };

            return new List<User>
            {
                new User { Id = 1, Pseudo = "John", Mail = "john@example.com", Pwd = "Test1234*", Address = null, Orders = null, Role = "User" },
                new User { Id = 2, Pseudo = "Jane", Mail = "jane@example.com", Pwd = "Test1234*", Address = null, Orders = null, Role = "User" },
                new User { Id = 3, Pseudo = "Bob", Mail = "bob@example.com", Pwd = "Test1234*", Address = null, Orders = null, Role = "User" },
                new User { Id = 4, Pseudo = "Lily", Mail = "lily@example.com", Pwd = "Test1234*", Address = adresses[0], Orders = null, Role = "User" },
                new User { Id = 5, Pseudo = "Marie", Mail = "marie@example.com", Pwd = "Test1235*", Address = adresses[1], Orders = null, Role = "User" },
                new User { Id = 6, Pseudo = "John", Mail = "jojo@example.com", Pwd = "Test1236*", Address = adresses[2], Orders = null, Role = "Admin" }
            };
        }


        internal static List<Address> GetAdressesData()
        {
            return new List<Address>
            {
                new Address { Id = 1, UserId = 4, City = "New York", Country = "USA", StreetName = "rue du fou", StreetNumber = 40, PhoneNumber = "0603030", PostalCode = 12345 },
                new Address { Id = 2, UserId = 5, City = "Los Angeles", Country = "UK", StreetName = "rue longue", StreetNumber = 4, PhoneNumber = "0606060", PostalCode = 54321 },
                new Address { Id = 3, UserId = 6, City = "New York", Country = "USA", StreetName = "rue de la tour", StreetNumber = 100, PhoneNumber = "0715224", PostalCode = 99999 }
            };
        }



    }
}
