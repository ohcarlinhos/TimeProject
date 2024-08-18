namespace Shared.General;

public class PaginationQuery
{
    private int _page = 1;

    public int Page
    {
        get => _page;
        set => _page = value <= 0 ? 1 : value;
    }

    public int PerPage { get; set; } = 10;
    public string? Search { get; set; } = "";
    public string? OrderBy { get; set; } = "";
    public string? Sort { get; set; } = "desc";
}