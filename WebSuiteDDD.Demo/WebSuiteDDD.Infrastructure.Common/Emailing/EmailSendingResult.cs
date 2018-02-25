namespace WebSuiteDDD.Infrastructure.Common.Emailing
{
    public class EmailSendingResult
    {
        public bool EmailSentSuccessfully { get; set; }
        public string EmailSendingFailureMessage { get; set; }
    }
}
