using TimeProject.Domain.Dtos.Categories;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Categories;

public class CategoryOutDto : ICategoryOutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}