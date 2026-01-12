using TimeProject.Domain.RemoveDependencies.Dtos.Category;

namespace TimeProject.Infrastructure.ObjectValues.Category;

public class CategoryOutDto : ICategoryOutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}