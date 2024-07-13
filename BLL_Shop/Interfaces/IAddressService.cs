using BLL_Shop.DTO.Address.Create;
using BLL_Shop.DTO.Address.Update;

using Microsoft.AspNetCore.Http;

namespace BLL_Shop.Interfaces
{
    public interface IAddressService
    {

        #region <-------------> CREATE <------------->
        Task<IResult> Create(AddressCreateDTO addressToAdd);
        #endregion



        #region <-------------> GET <------------->
        Task<IResult> GetAll();
        Task<IResult> GetByPostalCode(int postalCode);
        Task<IResult> GetByCity(string city);
        Task<IResult> GetByCountry(string country);
        #endregion



        #region <-------------> UPDATE <------------->
        Task<IResult> Update(int id, AddressCountryUpdateDTO addressToAdd);
        Task<IResult> UpdateCity(int id, AddressCityUpdateDTO addressToAdd);
        Task<IResult> UpdatePhoneNumber(int id, AddressPhoneNumberUpdateDTO addressToAdd);
        #endregion



        #region <-------------> DELETE <------------->
        Task<IResult> Delete(int id);
        #endregion
    }
}
