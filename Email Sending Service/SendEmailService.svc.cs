using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Mail;

namespace Email_Sending_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SendEmailService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SendEmailService.svc or SendEmailService.svc.cs at the Solution Explorer and start debugging.
    public class SendEmailService : ISendEmailService
    {
        public void SendEmail(string from, string to, string body, string subject, string password)
        {
            MailMessage mailMessage = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body
            };
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new System.Net.NetworkCredential()
                {
                    UserName = from,
                    Password = password
                },

                EnableSsl = true
            };
            smtpClient.Send(mailMessage);
        }
    }
}
