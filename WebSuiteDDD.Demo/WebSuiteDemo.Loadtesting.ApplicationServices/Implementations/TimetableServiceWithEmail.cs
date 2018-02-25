using System;
using System.Linq;
using System.Threading.Tasks;
using WebSuiteDDD.Infrastructure.Common.Emailing;
using WebSuiteDemo.Loadtesting.ApplicationServices.Abstractions;
using WebSuiteDemo.Loadtesting.ApplicationServices.Messaging;
using WebSuiteDemo.Loadtesting.Domain;

namespace WebSuiteDemo.Loadtesting.ApplicationServices.Implementations
{
    public class TimetableServiceWithEmail : ITimetableService
    {
        private readonly ITimetableService _innerTimetableService;
        private readonly IEmailService _emailService;

        public TimetableServiceWithEmail(ITimetableService innerTimetableSerivce, IEmailService emailService)
        {
            if (innerTimetableSerivce == null) throw new ArgumentNullException("innerTimetableSerivce");
            if (emailService == null) throw new ArgumentNullException("emailService");
            _innerTimetableService = innerTimetableSerivce;
            _emailService = emailService;
        }

        public async Task<AddOrUpdateLoadtestsResponse> AddOrUpdateLoadtestsAsync(AddOrUpdateLoadtestsRequest request)
        {
            AddOrUpdateLoadtestsResponse resp = await _innerTimetableService.AddOrUpdateLoadtestsAsync(request);
            if (resp.Exception == null)
            {
                AddOrUpdateLoadTestsValidationResult validationResult = resp.AddOrUpdateLoadtestsValidationResult;
                if ((validationResult.ToBeInserted.Any() || validationResult.ToBeUpdated.Any())
                    && !validationResult.Failed.Any())
                {
                    EmailArguments args = new EmailArguments("Load tests added or updated", "Load tests added or updated", "My boss", "Developer1", "127.0.0.1");
                    _emailService.SendMail(args);
                }
            }

            return resp;
        }

        public async Task<DeleteLoadtestResponse> DeleteLoadtestAsync(DeleteLoadtestRequest request)
        {
            return await _innerTimetableService.DeleteLoadtestAsync(request);
        }

        public async Task<GetLoadtestsForTimePeriodResponse> GetLoadtestsForTimePeriodAsync(GetLoadtestsForTimePeriodRequest request)
        {
            return await _innerTimetableService.GetLoadtestsForTimePeriodAsync(request);
        }
    }
}
