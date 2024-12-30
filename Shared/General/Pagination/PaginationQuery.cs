namespace Shared.General.Pagination;

public class PaginationQuery
{
    private int _page = 1;

    public int Page
    {
        get => _page;
        set => _page = value <= 0 ? 1 : value;
    }

    private int _perPage = 10;

    public virtual int PerPage
    {
        get => _perPage;
        set => _perPage = value <= 0 ? 1 : value > 30 ? 30 : value;
    }

    public string? Search { get; set; } = string.Empty;
    public string? OrderBy { get; set; } = string.Empty;
    public string? Sort { get; set; } = "asc";
    public string? SortProp { get; set; }
    public IEnumerable<string>? Filters { get; set; }
}