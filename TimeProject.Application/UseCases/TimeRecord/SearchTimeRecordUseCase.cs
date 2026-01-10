using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeRecord;

public class SearchTimeRecordUseCase(ITimeRecordRepository repo) : ISearchTimeRecordUseCase
{
    public async Task<ICustomResult<IList<SearchTimeRecordItem>>> Handle(string search, int userId)
    {
        var result = new CustomResult<IList<SearchTimeRecordItem>>();
        return result.SetData(await repo.SearchTimeRecord(search, userId));
    }
}