namespace TimeProject.Domain.Entities.Shared;

public interface IMultipleTimeRelationsEntity
{
    int? RecordId { get; set; }
    int? SessionId { get; set; }
    int? CategoryId { get; set; }
}