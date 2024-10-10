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
        set
        {
            switch (value)
            {
                case < 0:
                    _perPage = 0;
                    return;
                case > 30:
                    _perPage = 30;
                    return;
            }
        }
    }

    public string? Search { get; set; } = string.Empty;
    public string? OrderBy { get; set; } = string.Empty;
    public string? Sort { get; set; } = "desc";
    public IEnumerable<string>? Filters { get; set; }
}