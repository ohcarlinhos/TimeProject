using System.ComponentModel.DataAnnotations;

namespace API.Modules.Category.Dto;

public class CategoryDto
{
    [MaxLength(20)] public string Name { get; set; }
}