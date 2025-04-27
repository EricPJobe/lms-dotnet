namespace lms_server.Helpers;

public class QueryObject
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Search { get; set; }
    public string? SortBy { get; set; }
    public bool Descending { get; set; } = false;

    public QueryObject(int page, int pageSize, string? search, string? sortBy, bool descending)
    {
        Page = page;
        PageSize = pageSize;
        Search = search;
        SortBy = sortBy;
        Descending = descending;
    }
}