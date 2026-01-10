namespace TimeProject.Domain.RemoveDependencies.Dtos.Category;

public class CategoryOutDto : ICategoryOutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}