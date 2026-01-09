using System.Net.Mail;

namespace TimeProject.Api.Infrastructure.Interfaces;

public interface ICustomSmtp
{
    void Send(MailMessage mailMessage);
}