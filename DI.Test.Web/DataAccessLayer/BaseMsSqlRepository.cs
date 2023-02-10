using DI.Test.Data;
using DI.Test.Web.Models.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DI.Test.Web.DataAccessLayer
{
    public class BaseMsSqlRepository<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        private bool disposed = false;
        private DbSet<TEntity> _objectSet;
        protected readonly MsSqlDbContext dbContext;

        protected DbSet<TEntity> DbSet => _objectSet ??= dbContext.Set<TEntity>();

        public BaseMsSqlRepository(MsSqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public delegate object ConstructorDelegate(params object[] args);

        public static ConstructorDelegate CreateConstructor(Type type, params Type[] parameters)
        {
            var constructorInfo = type.GetConstructor(parameters);

            var paramExpr = Expression.Parameter(typeof(Object[]));

            var constructorParameters = parameters.Select((paramType, index) =>
                Expression.Convert(
                    Expression.ArrayAccess(
                        paramExpr,
                        Expression.Constant(index)),
                    paramType)).ToArray();

            var body = Expression.New(constructorInfo, constructorParameters);
            var constructor = Expression.Lambda<ConstructorDelegate>(body, paramExpr);

            return constructor.Compile();
        }

        public virtual IQueryable<TViewModel> GetAll()
        {
            var myConstructor = CreateConstructor(typeof(TViewModel), typeof(TEntity));

            return DbSet.Select(s => (TViewModel)myConstructor(s));
        }

        public virtual PagedList<TViewModel> GetAll(QueryOptions options)
        {
            IQueryable<TEntity> query = DbSet;

            if (options != null)
            {
                if (!string.IsNullOrEmpty(options.SearchPropertyName) && !string.IsNullOrEmpty(options.SearchTerm))
                {
                    query = PagedListSupport<TEntity>.Search(query, options.SearchPropertyName, options.SearchTerm);
                }

                if (!string.IsNullOrEmpty(options.OrderPropertyName) && options.DescendingOrder.HasValue)
                {
                    query = PagedListSupport<TEntity>.Order(query, options.OrderPropertyName, options.DescendingOrder.Value);
                }
            }

            var myConstructor = CreateConstructor(typeof(TViewModel), typeof(TEntity));

            return new PagedList<TViewModel>(query.Select(s => (TViewModel)myConstructor(s)), options);
        }

        public bool FindEntity(int id, out TEntity item)
        {
            item = DbSet.Find(id);
            return item != null;
        }

        public bool ExistsEntity(int id)
        {
            TEntity item = DbSet.Find(id);
            return item != null;
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
