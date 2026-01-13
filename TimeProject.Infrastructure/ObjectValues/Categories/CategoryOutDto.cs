using TimeProject.Domain.Dtos.Categories;

namespace TimeProject.Infrastructure.ObjectValues.Categories;

public class CategoryOutDto : ICategoryOutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}