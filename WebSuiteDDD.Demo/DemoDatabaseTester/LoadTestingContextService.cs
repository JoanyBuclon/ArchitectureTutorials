using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebSuiteDemo.Loadtesting.Domain;
using WebSuiteDemo.Loadtesting.Repository.EF;
using WebSuiteDemo.Loadtesting.Repository.EF.Repositories;

namespace DemoDatabaseTester
{
    public class LoadTestingContextService
    {
        public void TestLoadTestingContext()
        {
            LoadTestingContext loadTestingContext = new LoadTestingContext();
            List<Agent> domainAgents = loadTestingContext.Agents.ToList();
            foreach (Agent agent in domainAgents)
            {
                Debug.WriteLine(string.Format("Id: {0}, city: {1}, country: {2}", agent.Id, agent.Location.City, agent.Location.Country));
            }
        }

        public void TestTimetableRepository()
        {
            ITimetableRepository timetableRepo = new TimetableRepository();
            IList<LoadTest> loadTests = timetableRepo.GetLoadTestsForTimePeriod(DateTime.UtcNow.AddDays(-10),
                DateTime.UtcNow.AddDays(10));

            Timetable tt = new Timetable(loadTests);

            LoadTest newLoadtest = new LoadTest(Guid.Parse("8c928a5e-d038-44f3-a8ff-70f64a651155"),
                new LoadTestParameters(DateTime.UtcNow.AddDays(3), 120, 900), Guid.Parse("751ec485-437d-4bae-9ff1-1923203a87b1")
                , Guid.Parse("99f4dc94-718c-450d-87b6-3153bb8db622"), Guid.Parse("471119e2-2b3c-4545-97a2-5f52d1fa7954")
                , Guid.Parse("a868a7c5-2f4a-43f7-9a8c-a597793fdc56"), Guid.Parse("96877388-ce4d-4ea8-ae93-438a696386b9")
                , Guid.Parse("73e25716-7622-4af6-99a0-0638efb1c8cc"));

            List<LoadTest> allChanges = new List<LoadTest>() { newLoadtest };
            AddOrUpdateLoadTestsValidationResult result = tt.AddOrUpdateLoadTests(allChanges);
            Debug.WriteLine(result.OperationResultSummary);

            timetableRepo.AddOrUpdateLoadTests(result);

            timetableRepo.DeleteById(Guid.Parse("4e880392-5497-4c9e-a3de-38f66348fe8e"));
        }
    }
}
