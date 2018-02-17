using System.Threading.Tasks;
using WebSuiteDemo.Loadtesting.ApplicationServices.Messaging;

namespace WebSuiteDemo.Loadtesting.ApplicationServices.Abstractions
{
    public interface ITimetableService
    {
        Task<AddOrUpdateLoadtestsResponse> AddOrUpdateLoadtestsAsync(AddOrUpdateLoadtestsRequest addOrUpdateLoadtestsRequest);
        Task<DeleteLoadtestResponse> DeleteLoadtestAsync(DeleteLoadtestRequest deleteLoadTestRequest);
        Task<GetLoadtestsForTimePeriodResponse> GetLoadtestsForTimePeriodAsync(GetLoadtestsForTimePeriodRequest getLoadtestsForTimePeriodRequest);
    }
}
