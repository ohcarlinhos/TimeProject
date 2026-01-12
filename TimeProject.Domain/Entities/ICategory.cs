namespace TimeProject.Domain.Entities;

public interface ICategory
{
    int Id { get; set; }
    string Name { get; set; }
    int UserId { get; set; }
}