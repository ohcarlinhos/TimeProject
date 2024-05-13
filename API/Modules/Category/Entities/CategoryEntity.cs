using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Modules.User.Entities;

namespace API.Modules.Category.Entities;

[Table("categories")]
public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    [Required, MinLength(3), MaxLength(120)]
    public string Name { get; set; }
}