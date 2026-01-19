using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Entities;

public class Project : IProject
{
    public int ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
}