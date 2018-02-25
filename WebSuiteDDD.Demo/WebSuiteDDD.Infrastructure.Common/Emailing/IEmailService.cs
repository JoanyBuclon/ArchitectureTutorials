namespace WebSuiteDDD.Infrastructure.Common.Emailing
{
    public interface IEmailService
    {
        EmailSendingResult SendMail(EmailArguments emailArguments);
    }
}
