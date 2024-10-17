using System.Net.Mail;

namespace API.Infra.Interfaces;

public interface ICustomSmtp
{ 
    void Send(MailMessage mailMessage);
}