using TimeProject.Application.ObjectValues;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Records;

public class SearchRecordUseCase(IRecordRepository repo) : ISearchRecordUseCase
{
    public ICustomResult<IList<SearchRecordItem>> Handle(string search, int userId)
    {
        var result = new CustomResult<IList<SearchRecordItem>>();
        return result.SetData(repo.SearchTimeRecord(search, userId));
    }
}