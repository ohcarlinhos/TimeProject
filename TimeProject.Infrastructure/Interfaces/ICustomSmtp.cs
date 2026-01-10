using System.Net.Mail;

namespace TimeProject.Infrastructure.Interfaces;

public interface ICustomSmtp
{
    void Send(MailMessage mailMessage);
}