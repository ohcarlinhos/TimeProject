using System.ComponentModel.DataAnnotations.Schema;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Shared;

namespace TimeProject.Infrastructure.Database.Entities;

[Table("categories")]
public class Category : WithOwnerEntity, ICategory
{
    [Column("category_id")] public int CategoryId { get; set; }
    [Column("name")] public string Name { get; set; } = string.Empty;
}