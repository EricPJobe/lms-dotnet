namespace lms_server.Helpers;

public class QueryObject
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 100;
    public string? SearchString { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool? IsDescending { get; set; } = false;
}