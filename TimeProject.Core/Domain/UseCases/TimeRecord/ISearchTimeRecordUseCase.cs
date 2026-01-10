using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface ISearchTimeRecordUseCase
{
    Task<Result<List<SearchTimeRecordItem>>> Handle(string search, int userId);
}