using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSuiteDemo.Loadtesting.ApplicationServices.Abstractions;
using WebSuiteDemo.Loadtesting.ApplicationServices.Messaging;
using WebSuiteDemo.Loadtesting.Domain;

namespace WebSuiteDemo.Loadtesting.ApplicationServices.Implementations
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _timetableRepository;
        private readonly ITimetableViewModelRepository _timetableViewModelRepository;

        public TimetableService(ITimetableRepository timetableRepository, ITimetableViewModelRepository timetableViewModelRepository)
        {
            if (timetableRepository == null) throw new ArgumentNullException("timetableRepository");
            if (timetableViewModelRepository == null) throw new ArgumentNullException("timetableViewModelRepository");
            _timetableRepository = timetableRepository;
            _timetableViewModelRepository = timetableViewModelRepository;
        }

        public async Task<AddOrUpdateLoadtestsResponse> AddOrUpdateLoadtestsAsync(AddOrUpdateLoadtestsRequest addOrUpdateLoadtestsRequest)
        {
            return await Task<AddOrUpdateLoadtestsResponse>.Run(() => AddOrUpdateLoadTests(addOrUpdateLoadtestsRequest));
        }

        public async Task<DeleteLoadtestResponse> DeleteLoadtestAsync(DeleteLoadtestRequest deleteLoadTestRequest)
        {
            return await Task<DeleteLoadtestResponse>.Run(() => DeleteLoadtest(deleteLoadTestRequest));
        }

        public async Task<GetLoadtestsForTimePeriodResponse> GetLoadtestsForTimePeriodAsync(GetLoadtestsForTimePeriodRequest getLoadtestsForTimePeriodRequest)
        {
            return await Task<GetLoadtestsForTimePeriodResponse>.Run(() => GetLoadtestsForTimePeriod(getLoadtestsForTimePeriodRequest));
        }

        private DeleteLoadtestResponse DeleteLoadtest(DeleteLoadtestRequest deleteLoadTestRequest)
        {
            DeleteLoadtestResponse resp = new DeleteLoadtestResponse();

            try
            {
                _timetableRepository.DeleteById(deleteLoadTestRequest.Id);
            }
            catch (Exception ex)
            {
                resp.Exception = ex;
            }

            return resp;
        }

        private GetLoadtestsForTimePeriodResponse GetLoadtestsForTimePeriod(GetLoadtestsForTimePeriodRequest request)
        {
            GetLoadtestsForTimePeriodResponse resp = new GetLoadtestsForTimePeriodResponse();

            try
            {
                IList<LoadTest> loadtests = _timetableRepository.GetLoadTestsForTimePeriod(request.SearchStartDateUtc, request.SearchEndDateUtc);
                IEnumerable<LoadTestViewModel> ltVms = _timetableViewModelRepository.ConvertToViewModel(loadtests);
                resp.Loadtests = ltVms;
            }
            catch (Exception ex)
            {
                resp.Exception = ex;
            }

            return resp;
        }

        private AddOrUpdateLoadtestsResponse AddOrUpdateLoadTests(AddOrUpdateLoadtestsRequest request)
        {
            AddOrUpdateLoadtestsResponse resp = new AddOrUpdateLoadtestsResponse();

            try
            {
                foreach (LoadTestViewModel vm in request.Loadtests)
                {
                    if (vm.Id == null || vm.Id == default(Guid))
                    {
                        vm.Id = Guid.NewGuid();
                    }
                }

                List<LoadTestViewModel> sortedByDate = request.Loadtests.OrderBy(l => l.StartDateUtc).ToList();
                LoadTestViewModel last = sortedByDate.Last();
                IList<LoadTest> loadtests = _timetableRepository.GetLoadTestsForTimePeriod(sortedByDate.First().StartDateUtc, last.StartDateUtc.AddSeconds(last.DurationSec));
                Timetable timetable = new Timetable(loadtests);
                IList<LoadTest> loadtestsAddedOrUpdated = _timetableViewModelRepository.ConvertToDomain(request.Loadtests);
                AddOrUpdateLoadTestsValidationResult validationResult = timetable.AddOrUpdateLoadTests(loadtestsAddedOrUpdated);
                _timetableRepository.AddOrUpdateLoadTests(validationResult);
                resp.AddOrUpdateLoadtestsValidationResult = validationResult;
            }
            catch (Exception ex)
            {
                resp.Exception = ex;
            }

            return resp;
        }
    }
}
