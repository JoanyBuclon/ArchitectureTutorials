using System;

namespace WebSuiteDemo.Loadtesting.ApplicationServices.Messaging
{
    public abstract class ServiceResponseBase
    {
        public Exception Exception { get; set; }
        public ServiceResponseBase()
        {
            this.Exception = null;
        }
    }
}
