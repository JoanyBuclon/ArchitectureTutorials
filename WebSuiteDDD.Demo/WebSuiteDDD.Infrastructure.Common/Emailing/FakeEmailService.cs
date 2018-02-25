using System.Diagnostics;

namespace WebSuiteDDD.Infrastructure.Common.Emailing
{
    public class FakeEmailService : IEmailService
    {
        public EmailSendingResult SendMail(EmailArguments emailArguments)
        {
            string message = string.Format("From: {0}; to {1}, message: {2}, server: {3}, subject: {4}",
                emailArguments.From, emailArguments.To, emailArguments.Message, emailArguments.SmtpServer, emailArguments.Subject);
            Debug.WriteLine(message);
            return new EmailSendingResult() { EmailSendingFailureMessage = "None", EmailSentSuccessfully = true };
        }
    }
}
