using System.Collections.Generic;
using WebSuiteDemo.Loadtesting.Domain;

namespace WebSuiteDemo.Loadtesting.ApplicationServices.Messaging
{
    public class AddOrUpdateLoadtestsRequest : ServiceRequestBase
    {
        private IEnumerable<LoadTestViewModel> _loadtests;

        public AddOrUpdateLoadtestsRequest(IEnumerable<LoadTestViewModel> loadtests)
        {
            _loadtests = loadtests;
        }

        public IEnumerable<LoadTestViewModel> Loadtests
        {
            get
            {
                return _loadtests;
            }
        }
    }
}
