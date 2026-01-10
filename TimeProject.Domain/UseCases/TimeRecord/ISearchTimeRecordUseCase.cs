using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Repositories;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ISearchTimeRecordUseCase
{
    Task<Result<List<SearchTimeRecordItem>>> Handle(string search, int userId);
}