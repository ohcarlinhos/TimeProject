using TimeProject.Domain.Repositories.Shared;

namespace TimeProject.Infrastructure.Repositories.Shared;

public class IndexRepositoryResult<T> : IIndexRepositoryResult<T>
{
    public int Count { get; set; }
    public IEnumerable<T> Entities { get; set; } = null!;
}