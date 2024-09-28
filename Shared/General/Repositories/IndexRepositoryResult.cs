namespace Shared.General.Repositories;

public class IndexRepositoryResult<T>
{
    public int Count { get; set; }
    public IEnumerable<T> Entities { get; set; } = null!;
}