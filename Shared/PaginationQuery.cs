namespace Shared;

public class PaginationQuery
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public string? Search { get; set; }
    public string? OrderBy { get; set; }
    public string? Sort { get; set; } = "desc";
}