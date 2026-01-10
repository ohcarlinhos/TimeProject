using TimeProject.Domain.RemoveDependencies.Dtos.Handlers.Email;

namespace TimeProject.Api.Infrastructure.Interfaces;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}