using System.Collections.Generic;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public interface ITimetableViewModelRepository
    {
        IList<LoadTestViewModel> ConvertToViewModel(IEnumerable<LoadTest> domains);
        IList<LoadTest> ConvertToDomain(IEnumerable<LoadTestViewModel> viewModels);
    }
}
