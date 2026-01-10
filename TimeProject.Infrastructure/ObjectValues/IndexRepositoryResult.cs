using TimeProject.Domain.ObjectValues;

namespace TimeProject.Infrastructure.ObjectValues;

public class IndexRepositoryResult<T> : IIndexRepositoryResult<T>
{
    public int Count { get; set; }
    public IEnumerable<T> Entities { get; set; } = null!;
}