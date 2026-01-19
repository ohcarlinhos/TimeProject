using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

public class Category : ICategory
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UserId { get; set; }
}