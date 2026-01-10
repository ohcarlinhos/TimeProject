using TimeProject.Core.Application.General.Repositories;

namespace TimeProject.Api.Infrastructure.Repositories;

public class IndexRepositoryResult<T> : IIndexRepositoryResult<T>
{
    public int Count { get; set; }
    public IEnumerable<T> Entities { get; set; } = null!;
}