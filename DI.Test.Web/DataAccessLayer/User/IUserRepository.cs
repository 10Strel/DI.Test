using DI.Test.Web.Models.Pagination;

namespace DI.Test.Web.DataAccessLayer.User
{
    public interface IUserRepository<UserViewModel> where UserViewModel : class
    {
        IQueryable<UserViewModel> GetAll();

        PagedList<UserViewModel> GetAll(QueryOptions queryOptions);

        bool Find(int id, out UserViewModel? item);

        bool Exists(int id);
    }
}
