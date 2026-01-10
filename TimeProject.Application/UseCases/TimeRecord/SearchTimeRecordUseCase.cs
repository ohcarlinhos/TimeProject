using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimeRecord;

public class SearchTimeRecordUseCase(ITimeRecordRepository repo) : ISearchTimeRecordUseCase
{
    public async Task<Result<List<SearchTimeRecordItem>>> Handle(string search, int userId)
    {
        var result = new Result<List<SearchTimeRecordItem>>();
        return result.SetData(await repo.SearchTimeRecord(search, userId));
    }
}