using System.Collections.Generic;
using WebSuiteDemo.Loadtesting.Domain;

namespace WebSuiteDemo.Loadtesting.ApplicationServices.Messaging
{
    public class GetLoadtestsForTimePeriodResponse : ServiceResponseBase
    {
        public IEnumerable<LoadTestViewModel> Loadtests { get; set; }
    }
}
