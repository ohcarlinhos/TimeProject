namespace TimeProject.Domain.Entities;

public interface ICustomer
{
    int Id { get; set; }
    string Name { get; set; }
    int UserId { get; set; }
}