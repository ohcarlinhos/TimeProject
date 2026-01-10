using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Repositories;

namespace TimeProject.Core.Domain.UseCases.TimeRecord;

public interface ISearchTimeRecordUseCase
{
    Task<Result<List<SearchTimeRecordItem>>> Handle(string search, int userId);
}