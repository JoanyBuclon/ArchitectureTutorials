using System;

namespace WebSuiteDDD.Infrastructure.Common.Emailing
{
    public class EmailArguments
    {
        private string _subject;
        private string _message;
        private string _to;
        private string _from;
        private string _smtpServer;

        public EmailArguments(string subject, string message, string to, string from, string smtpServer)
        {
            if (string.IsNullOrEmpty(subject)) throw new ArgumentNullException("subject");
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException("message");
            if (string.IsNullOrEmpty(to)) throw new ArgumentNullException("to");
            if (string.IsNullOrEmpty(from)) throw new ArgumentNullException("from");
            if (string.IsNullOrEmpty(smtpServer)) throw new ArgumentNullException("smtpServer");

            this._from = from;
            this._message = message;
            this._smtpServer = smtpServer;
            this._subject = subject;
            this._to = to;
        }

        public string To
        {
            get
            {
                return this._to;
            }
        }

        public string From
        {
            get
            {
                return this._from;
            }
        }

        public string Message
        {
            get
            {
                return this._message;
            }
        }

        public string SmtpServer
        {
            get
            {
                return this._smtpServer;
            }
        }

        public string Subject
        {
            get
            {
                return this._subject;
            }
        }
    }
}
