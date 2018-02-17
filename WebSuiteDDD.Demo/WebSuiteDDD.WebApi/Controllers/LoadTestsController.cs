using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebSuiteDDD.WebApi.Models;
using WebSuiteDemo.Loadtesting.ApplicationServices.Abstractions;
using WebSuiteDemo.Loadtesting.ApplicationServices.Messaging;
using WebSuiteDemo.Loadtesting.Domain;

namespace WebSuiteDDD.WebApi.Controllers
{
    public class LoadTestsController : ApiController
    {
        private readonly ITimetableService _timetableService;

        public LoadTestsController(ITimetableService timetableService)
        {
            if (timetableService == null) throw new ArgumentNullException("timetableService");
            _timetableService = timetableService;
        }

        public async Task<IHttpActionResult> Get()
        {
            GetLoadtestsForTimePeriodRequest request = new GetLoadtestsForTimePeriodRequest(DateTime.UtcNow, DateTime.UtcNow.AddDays(14));
            GetLoadtestsForTimePeriodResponse response = await _timetableService.GetLoadtestsForTimePeriodAsync(request);

            if (response.Exception == null)
            {
                return Ok<IEnumerable<LoadTestViewModel>>(response.Loadtests);
            }

            return InternalServerError(response.Exception);
        }

        public async Task<IHttpActionResult> Post(IEnumerable<InsertUpdateLoadtestViewModel> insertUpdateLoadtestViewModel)
        {
            List<LoadTestViewModel> loadtestViewModel = new List<LoadTestViewModel>();
            foreach (InsertUpdateLoadtestViewModel vm in insertUpdateLoadtestViewModel)
            {
                loadtestViewModel.Add(vm.ConvertToViewModel());
            }

            AddOrUpdateLoadtestsRequest request = new AddOrUpdateLoadtestsRequest(loadtestViewModel);
            AddOrUpdateLoadtestsResponse response = await _timetableService.AddOrUpdateLoadtestsAsync(request);

            if (response.Exception == null)
            {
                return Ok<string>(response.AddOrUpdateLoadtestsValidationResult.OperationResultSummary);
            }

            return InternalServerError(response.Exception);
        }

        public async Task<IHttpActionResult> Delete(Guid id)
        {
            DeleteLoadtestRequest request = new DeleteLoadtestRequest(id);
            DeleteLoadtestResponse response = await _timetableService.DeleteLoadtestAsync(request);

            if (response.Exception == null)
            {
                return Ok<string>("Deleted");
            }

            return InternalServerError(response.Exception);
        }
    }
}
