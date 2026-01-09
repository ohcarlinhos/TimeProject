using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.Application.Dtos.Category;

public class CategoryDto
{
    [MaxLength(20)] public string Name { get; set; } = string.Empty;
}