namespace TimeProject.Core.Application.General.Repositories;

public interface IIndexRepositoryResult<T>
{
    int Count { get; set; }
    IEnumerable<T> Entities { get; set; }
}