using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

public class Project : WithOwnerEntity, IProject
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}