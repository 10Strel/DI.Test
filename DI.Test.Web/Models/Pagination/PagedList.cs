namespace DI.Test.Web.Models.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public PagedList(IQueryable<T> query, QueryOptions? options = null)
        {
            CurrentPage = options != null ? options.CurrentPage : QueryOptions.CURRENT_PAGE;
            PageSize = options != null ? options.PageSize : QueryOptions.PAGE_SIZE;
            TotalPages = query.Count() / PageSize;
            AddRange(query.Skip((CurrentPage - 1) * PageSize).Take(PageSize));
        }
    }
}