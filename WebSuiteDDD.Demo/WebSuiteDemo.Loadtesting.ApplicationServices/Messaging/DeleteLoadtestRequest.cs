using System;

namespace WebSuiteDemo.Loadtesting.ApplicationServices.Messaging
{
    public class DeleteLoadtestRequest : ServiceRequestBase
    {
        private Guid _id;

        public DeleteLoadtestRequest(Guid id)
        {
            _id = id;
        }

        public Guid Id
        {
            get
            {
                return _id;
            }
        }
    }
}
