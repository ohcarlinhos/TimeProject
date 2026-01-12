namespace TimeProject.Domain.ObjectValues;

public interface IPaginationQuery
{
    int Page { get; set; }
    int PerPage { get; set; }
    string? Search { get; set; }
    string? OrderBy { get; set; }
    string? Sort { get; set; }
    string? SortProp { get; set; }
    IEnumerable<string>? Filters { get; set; }
}