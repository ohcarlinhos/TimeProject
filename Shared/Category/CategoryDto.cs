using System.ComponentModel.DataAnnotations;

namespace Shared.Category;

public class CategoryDto
{
    [MaxLength(20)] public string Name { get; set; }
}