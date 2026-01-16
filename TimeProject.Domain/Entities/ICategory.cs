namespace TimeProject.Domain.Entities;

public interface ICategory
{
    int CategoryId { get; set; }
    string Name { get; set; }
    int UserId { get; set; }
}