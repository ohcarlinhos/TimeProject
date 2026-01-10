using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.RemoveDependencies.Dtos.Category;

public class CategoryDto
{
    [MaxLength(20)] public string Name { get; set; } = string.Empty;
}