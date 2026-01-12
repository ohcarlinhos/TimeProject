namespace TimeProject.Domain.ObjectValues;

public interface IPagination<T>
{
    int Page { get; set; }
    int PerPage { get; set; }
    int TotalPages { get; set; }
    int TotalItems { get; set; }
    IEnumerable<T>? Data { get; set; }
    string? Search { get; set; }
    string? OrderBy { get; set; }
    string? Sort { get; set; }
    string? SortProp { get; set; }
}