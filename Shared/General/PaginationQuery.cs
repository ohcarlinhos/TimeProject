namespace Shared.General;

public class PaginationQuery
{
    public int Page { get; set; } = 1;
    public int PerPage { get; set; } = 10;
    public string? Search { get; set; } = "";
    public string? OrderBy { get; set; } = "";
    public string? Sort { get; set; } = "desc";
}