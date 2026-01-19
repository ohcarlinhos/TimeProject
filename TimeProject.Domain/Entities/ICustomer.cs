using TimeProject.Domain.Entities.Shared;

namespace TimeProject.Domain.Entities;

public interface ICustomer
{
    int CustomerId { get; set; }
    string Name { get; set; }
    int UserId { get; set; }
}