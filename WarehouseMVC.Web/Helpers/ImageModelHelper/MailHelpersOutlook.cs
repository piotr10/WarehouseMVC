using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace WarehouseMVC.Web.Helpers.ImageModelHelper
{
    public class MailHelpersOutlook
    {
        private readonly IConfiguration _configuration;

        public MailHelpersOutlook(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Send(string from, string to, string subject, string content, List<string> attachments)
        {
            try
            {
                var host = _configuration["Outlook:Host"];
                var port = int.Parse(_configuration["Outlook:Port"]);
                var username = _configuration["Outlook:Username"];
                var password = _configuration["Outlook:Password"];
                var enable = bool.Parse(_configuration["Outlook:SMTP:starttls:enable"]);

                var smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enable,
                    Credentials = new NetworkCredential(username, password)
                };

                var mailMessage = new MailMessage(from, to);
                mailMessage.Subject = subject;
                mailMessage.Body = content;
                mailMessage.IsBodyHtml = true;
                if (attachments != null)
                {
                    foreach (var attachment in attachments)
                    {
                        mailMessage.Attachments.Add(new Attachment(attachment));
                    }
                }

                smtpClient.Send(mailMessage);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}