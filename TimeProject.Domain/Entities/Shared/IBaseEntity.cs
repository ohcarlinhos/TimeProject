namespace TimeProject.Domain.Entities.Shared;

public interface IBaseEntity
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}