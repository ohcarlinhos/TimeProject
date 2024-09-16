using System.Net.Mail;

namespace API.Integrations.Smtp;

public interface ICustomSmtp
{ 
    void Send(MailMessage mailMessage);
}