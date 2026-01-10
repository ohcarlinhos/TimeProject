using TimeProject.Core.Application.General.Repositories;

namespace TimeProject.Api.Repositories.Shared;

public class IndexRepositoryResult<T> : IIndexRepositoryResult<T>
{
    public int Count { get; set; }
    public IEnumerable<T> Entities { get; set; } = null!;
}