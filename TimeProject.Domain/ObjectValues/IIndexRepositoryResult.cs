namespace TimeProject.Domain.ObjectValues;

public interface IIndexRepositoryResult<T>
{
    int Count { get; set; }
    IEnumerable<T> Entities { get; set; }
}