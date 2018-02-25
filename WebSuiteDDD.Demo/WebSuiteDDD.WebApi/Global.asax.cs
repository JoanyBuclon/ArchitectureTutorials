using System.Web.Http;
using WebSuiteDDD.Infrastructure.Common.Emailing;
using WebSuiteDDD.SharedKernel.DomainEvents;
using WebSuiteDemo.Loadtesting.ApplicationServices.Implementations;

namespace WebSuiteDDD.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DomainEventMediator.RegisterDomainEventHandler(new TimetableChangedEmailEventHandler(new FakeEmailService()));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
