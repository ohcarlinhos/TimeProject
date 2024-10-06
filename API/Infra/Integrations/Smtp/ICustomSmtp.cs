using System.Net.Mail;

namespace API.Infra.Integrations.Smtp;

public interface ICustomSmtp
{ 
    void Send(MailMessage mailMessage);
}