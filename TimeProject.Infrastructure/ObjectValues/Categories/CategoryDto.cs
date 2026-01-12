using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;

namespace TimeProject.Infrastructure.ObjectValues.Categories;

public class CategoryDto : ICategoryDto
{
    [MaxLength(20)] public string Name { get; set; } = string.Empty;
}