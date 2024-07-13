using Database_Shop.Entity;

namespace DAL_Shop.Interfaces
{
    public interface ICategoryRepository
    {

        #region <-------------> CREATE <------------->
        Task<Category?> Create(Category category);
        #endregion



        #region <-------------> GET <------------->
        Task<List<Category>> GetAll();
        Task<Category?> GetById(int id);
        #endregion



        #region <-------------> UPDATE <------------->
        Task<Category?> Update(int id, string name);
        #endregion



        #region <-------------> DELETE <------------->
        Task<bool> Delete(int id);
        #endregion
    }
}
