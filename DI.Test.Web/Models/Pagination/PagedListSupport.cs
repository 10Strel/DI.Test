using System.Linq.Expressions;

namespace DI.Test.Web.Models.Pagination
{
    public class PagedListSupport<T>
    {
        public static IQueryable<T> Order(IQueryable<T> query, string propertyName, bool desc)
        {
            var parameter = Expression.Parameter(typeof(T), "х");
            var source = propertyName.Split('.').Aggregate((Expression)parameter, Expression.Property);
            var lamЬda = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(T), source.Type), source, parameter);

            return typeof(Queryable).GetMethods().Single(
                    method => method.Name == (desc ? "OrderByDescending" : "OrderBy")
                    && method.IsGenericMethodDefinition
                    && method.GetGenericArguments().Length == 2
                    && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), source.Type)
                .Invoke(null, new object[] { query, lamЬda }) as IQueryable<T>;
        }

        public static IQueryable<T> Search(IQueryable<T> query, string propertyName, string searchTerm)
        {
            var parameter = Expression.Parameter(typeof(T), "х");
            var source = propertyName.Split('.').Aggregate((Expression)parameter, Expression.Property);
            var body = Expression.Call(source, "Contains", Type.EmptyTypes, Expression.Constant(searchTerm, typeof(string)));
            var lamЬda = Expression.Lambda<Func<T, bool>>(body, parameter);
            return query.Where(lamЬda);
        }
    }
}