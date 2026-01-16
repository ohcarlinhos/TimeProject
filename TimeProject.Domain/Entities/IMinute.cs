using TimeProject.Domain.Entities.Shared;

namespace TimeProject.Domain.Entities;

public interface IMinute : IMultipleTimeRelationsEntity, IWithOwnerEntity
{
    int MinuteId { get; set; }
    int Total { get; set; }
    DateTime Date { get; set; }
}