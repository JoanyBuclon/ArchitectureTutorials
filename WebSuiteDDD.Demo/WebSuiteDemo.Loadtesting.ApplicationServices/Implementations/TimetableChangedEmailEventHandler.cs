using System;
using System.Linq;
using WebSuiteDDD.Infrastructure.Common.Emailing;
using WebSuiteDDD.SharedKernel.DomainEvents;
using WebSuiteDemo.Loadtesting.Domain;
using WebSuiteDemo.Loadtesting.Domain.DomainEvents;

namespace WebSuiteDemo.Loadtesting.ApplicationServices.Implementations
{
    public class TimetableChangedEmailEventHandler : IDomainEventHandler
    {
        private readonly IEmailService _emailService;

        public TimetableChangedEmailEventHandler(IEmailService emailService)
        {
            if (emailService == null) throw new ArgumentNullException("emailService");
            _emailService = emailService;
        }

        public void Handle(EventArgs eventArgs)
        {
            TimetableChangedEventArgs e = eventArgs as TimetableChangedEventArgs;
            if (e != null)
            {
                AddOrUpdateLoadTestsValidationResult validationResult = e.AddOrUpdateLoadtestsValidationResult;
                if ((validationResult.ToBeInserted.Any() || validationResult.ToBeUpdated.Any())
                    && !validationResult.Failed.Any())
                {
                    EmailArguments args = new EmailArguments("Load tests added or updated", "Load tests added or updated", "My boss", "Developer1", "127.0.0.1");
                    _emailService.SendMail(args);
                }
            }
        }
    }
}
