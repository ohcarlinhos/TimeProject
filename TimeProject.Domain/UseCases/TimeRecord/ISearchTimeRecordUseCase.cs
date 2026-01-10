using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ISearchTimeRecordUseCase
{
    Task<ICustomResult<IList<SearchTimeRecordItem>>> Handle(string search, int userId);
}