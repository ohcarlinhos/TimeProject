using System.Net.Mail;

namespace App.Infrastructure.Interfaces;

public interface ICustomSmtp
{ 
    void Send(MailMessage mailMessage);
}