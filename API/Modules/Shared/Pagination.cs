namespace API.Modules.Shared;

public class Pagination<T>
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public List<T>? Data { get; set; }

    public static Pagination<T> Handle(List<T> data, int page, int perPage, int totalItems)
    {
        return new Pagination<T>()
        {
            Page = page,
            PerPage = perPage,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling((float)totalItems / perPage),
            Data = data
        };
    }
}