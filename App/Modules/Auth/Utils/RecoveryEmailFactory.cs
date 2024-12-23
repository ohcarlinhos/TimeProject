using Shared.Handlers.Email;

namespace App.Modules.Auth.Utils;

public static class RecoveryEmailFactory
{
    public static EmailPayload Create(string email, string url, string dateLimit)
    {
        return new EmailPayload
        {
            To = email,
            Subject = "Recuperação de Senha - Registra meu tempo aí!",
            Body = EmailFactory
                .InjectBody("""
                            <span class="preheader">Você acabou de requisitar a recuperação de senha...</span>
                            <table role="presentation" border="0" cellpadding="0" cellspacing="0" class="main">
                            
                             <!-- START MAIN CONTENT AREA -->
                             <tr>
                               <td class="wrapper">
                                 <p>Você acabou de requisitar a recuperação de senha.</p>
                                 <table role="presentation" border="0" cellpadding="0" cellspacing="0" class="btn btn-primary">
                                   <tbody>
                                     <tr>
                                       <td align="left">
                                         <table role="presentation" border="0" cellpadding="0" cellspacing="0">
                                           <tbody>
                                             <tr>
                                               <td>
                            """
                            + $"<a href='{url}' target=\"_blank\">Recriar senha</a>" +
                            """
                                               </td>
                                             </tr>
                                           </tbody>
                                         </table>
                                       </td>
                                     </tr>
                                   </tbody>
                                 </table>
                                 <p>
                            """
                            + $"Expiração do código: {dateLimit}" +
                            """
                                 </p>
                               </td>
                             </tr>
                            
                             <!-- END MAIN CONTENT AREA -->
                            </table>
                            """),
            IsHtml = true,
        };
    }
}
