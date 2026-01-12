using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Users;

public class UpdateUserDto : IUpdateUserDto
{
    [MinLength(2)] [MaxLength(120)] public string? Name { get; set; }
    [EmailAddress] [MaxLength(64)] public string? Email { get; set; }
    [MinLength(8)] [MaxLength(48)] public string? Password { get; set; }
    [Range(-12, 13)] public int? Utc { get; set; }
}