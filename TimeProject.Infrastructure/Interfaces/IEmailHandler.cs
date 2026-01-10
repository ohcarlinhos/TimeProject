using TimeProject.Core.RemoveDependencies.Dtos.Handlers.Email;

namespace TimeProject.Api.Infrastructure.Interfaces;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}