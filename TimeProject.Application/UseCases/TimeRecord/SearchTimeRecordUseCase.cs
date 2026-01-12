using TimeProject.Application.ObjectValues;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeRecord;

public class SearchTimeRecordUseCase(IRecordRepository repo) : ISearchTimeRecordUseCase
{
    public async Task<ICustomResult<IList<SearchRecordItem>>> Handle(string search, int userId)
    {
        var result = new CustomResult<IList<SearchRecordItem>>();
        return result.SetData(await repo.SearchTimeRecord(search, userId));
    }
}