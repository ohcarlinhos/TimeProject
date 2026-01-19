using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Database.Entities;

public class Customer : ICustomer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
}