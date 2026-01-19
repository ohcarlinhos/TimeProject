namespace TimeProject.Domain.Entities;

public interface IProject
{
    int ProjectId { get; set; }
    string Name { get; set; }
    int UserId { get; set; }
}