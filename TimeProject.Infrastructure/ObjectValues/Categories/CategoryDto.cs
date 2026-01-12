using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Categories;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Categories;

public class CategoryDto : ICategoryDto
{
    [MaxLength(20)] public string Name { get; set; } = string.Empty;
}