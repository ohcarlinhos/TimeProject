using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("customers")]
public class Customer : WithOwnerEntity, ICustomer
{
    [Column("customer_id")] public int CustomerId { get; set; }
    [Column("name")] public string Name { get; set; } = string.Empty;
}