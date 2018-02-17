using WebSuiteDemo.Loadtesting.Domain;

namespace WebSuiteDemo.Loadtesting.ApplicationServices.Messaging
{
    public class AddOrUpdateLoadtestsResponse : ServiceResponseBase
    {
        public AddOrUpdateLoadTestsValidationResult AddOrUpdateLoadtestsValidationResult { get; set; }
    }
}
