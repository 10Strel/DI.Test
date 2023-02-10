using DI.Test.Data;
using Entity = DI.Test.Data.Entities.User;
using ViewModel = DI.Test.Web.Models.UserViewModel;

namespace DI.Test.Web.DataAccessLayer.User
{
    public class UserRepository: BaseMsSqlRepository<Entity, ViewModel>, IUserRepository<ViewModel>
    {
        public UserRepository(MsSqlDbContext dbContext) : base(dbContext) { }

        public bool Find(int id, out ViewModel? item)
        {
            item = null;
            bool res = FindEntity(id, out Entity entity);

            if (!res)
                return false;

            item = new ViewModel(entity);
            return item != null;
        }

        public bool Exists(int id)
        {
            return ExistsEntity(id);
        }        
    }
}
