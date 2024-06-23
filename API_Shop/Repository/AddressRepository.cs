using API_Shop.DB.Context;
using API_Shop.Interfaces;
using API_Shop.Models;

using Microsoft.EntityFrameworkCore;

namespace API_Shop.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ShopDB _shopDB;
        public AddressRepository(ShopDB ctx) => _shopDB = ctx; 


        public async Task<Address?> Create(Address addressToAdd)
        {
            var result = await _shopDB.Address.AddAsync(addressToAdd);
            await _shopDB.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _shopDB.Address.FindAsync(id);

            if (result is null) return false;
            else
            {
                _shopDB.Address.Remove(result);
                await _shopDB.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IEnumerable<Address?>> GetAll()
        {
            var result = await _shopDB.Address.ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Address?>> GetByPostalCode(int postalCode)
        {
            var result = await _shopDB.Address.Where(a => a.PostalCode == postalCode).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Address?>> GetByCity(string city)
        {
            var result = await _shopDB.Address.Where(a => a.City == city).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Address?>> GetByCountry(string country)
        {
            var result = await _shopDB.Address.Where(a => a.Country == country).ToListAsync();

            return result;
        }

        public async Task<Address?> Update(int id, Address addressToAdd)
        {
            var result = await _shopDB.Address.FindAsync(id);

            if(result is null) return result;
            else
            {
                result.StreetNumber = addressToAdd.StreetNumber;
                result.City = addressToAdd.City;
                result.Country = addressToAdd.Country;
                result.PostalCode = addressToAdd.PostalCode;

                await _shopDB.SaveChangesAsync();
            }
            return result;
        }
    }
}
