namespace TimeProject.Core.Domain.Repositories.Shared;

public interface IIndexRepositoryResult<T>
{
    int Count { get; set; }
    IEnumerable<T> Entities { get; set; }
}