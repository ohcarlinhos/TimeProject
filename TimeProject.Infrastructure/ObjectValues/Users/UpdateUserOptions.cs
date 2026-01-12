using TimeProject.Domain.ObjectValues;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Users;

public class UpdateUserOptions : IUpdateUserOptions
{
    public bool UpdateFromAdmin { get; set; }
}