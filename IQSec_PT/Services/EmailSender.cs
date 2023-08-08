using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace IQSec_PT.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(
                           ILogger<EmailSender> logger)
        {

            _logger = logger;
        }


        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {

            await Execute(subject, message, toEmail);
        }

        public async Task<bool> Execute(string subject, string message, string toEmail)
        {

            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress("Roberto", "iqsec@mirandamx.dev");
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress("Usuario", toEmail);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Bcc.Add(new MailboxAddress("Roberto", "resback@gmail.com"));

                    emailMessage.Subject = subject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.TextBody = message;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        await mailClient.ConnectAsync("mirandamx.dev", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                        await mailClient.AuthenticateAsync("iqsec@mirandamx.dev", "8DWrykLauJ!J.if");
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                return false;
            }

        }
    }
}
