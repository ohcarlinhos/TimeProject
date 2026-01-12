namespace TimeProject.Domain.Entities;

public interface IProject
{
    int Id { get; set; }
    string Name { get; set; }
    int UserId { get; set; }
}