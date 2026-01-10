using TimeProject.Core.Domain.Utils;

namespace TimeProject.Application.UseCases.User.General;

public class UpdateUserOptions : IUpdateUserOptions
{
    public bool UpdateFromAdmin { get; set; }
}