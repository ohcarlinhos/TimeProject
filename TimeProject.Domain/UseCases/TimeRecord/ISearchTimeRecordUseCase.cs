using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ISearchTimeRecordUseCase
{
    ICustomResult<IList<SearchRecordItem>> Handle(string search, int userId);
}