namespace DI.Test.Web.Models.Pagination
{
    public class QueryOptions
    {
        public const int CURRENT_PAGE = 1;
        public const int PAGE_SIZE = 10;

        public int CurrentPage { get; set; } = CURRENT_PAGE;
        public int PageSize { get; set; } = PAGE_SIZE;

        public string? OrderPropertyName { get; set; }
        public bool? DescendingOrder { get; set; }
        public string? SearchPropertyName { get; set; }
        public string? SearchTerm { get; set; }
    }
}