using TimeProject.Domain.Entities.Shared;

namespace TimeProject.Domain.Entities;

public interface ICustomer : IWithOwnerEntity
{
    int CustomerId { get; set; }
    string Name { get; set; }
}