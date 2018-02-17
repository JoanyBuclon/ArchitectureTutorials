using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using WebSuiteDemo.Loadtesting.Domain;

namespace WebSuiteDemo.Loadtesting.Repository.EF.Repositories
{
    public class TimetableRepository : ITimetableRepository
    {
        public IList<LoadTest> GetLoadTestsForTimePeriod(DateTime searchStartDateUtc, DateTime searchEndDateUtc)
        {
            LoadTestingContext context = new LoadTestingContext();
            return (from l in context.LoadTests
                    where (l.Parameters.StartDateUtc <= searchStartDateUtc
                                && SqlFunctions.DateAdd("s", l.Parameters.DurationSec, l.Parameters.StartDateUtc) >= searchStartDateUtc)
                            ||
                            (l.Parameters.StartDateUtc <= searchEndDateUtc
                                && SqlFunctions.DateAdd("s", l.Parameters.DurationSec, l.Parameters.StartDateUtc) >= searchEndDateUtc)
                            ||
                            (l.Parameters.StartDateUtc <= searchStartDateUtc
                                && SqlFunctions.DateAdd("s", l.Parameters.DurationSec, l.Parameters.StartDateUtc) >= searchEndDateUtc)
                            ||
                            (l.Parameters.StartDateUtc >= searchStartDateUtc
                                && SqlFunctions.DateAdd("s", l.Parameters.DurationSec, l.Parameters.StartDateUtc) <= searchEndDateUtc)
                    select l).ToList();

        }

        public void AddOrUpdateLoadTests(AddOrUpdateLoadTestsValidationResult addOrUpdateLoadTestsValidationResult)
        {
            LoadTestingContext context = new LoadTestingContext();
            if (addOrUpdateLoadTestsValidationResult.ValidationComplete)
            {
                if (addOrUpdateLoadTestsValidationResult.ToBeInserted.Any())
                {
                    foreach (LoadTest toBeInserted in addOrUpdateLoadTestsValidationResult.ToBeInserted)
                    {
                        context.Entry<LoadTest>(toBeInserted).State = System.Data.Entity.EntityState.Added;
                    }
                }

                if (addOrUpdateLoadTestsValidationResult.ToBeUpdated.Any())
                {
                    foreach (LoadTest toBeUpdated in addOrUpdateLoadTestsValidationResult.ToBeUpdated)
                    {
                        context.Entry<LoadTest>(toBeUpdated).State = System.Data.Entity.EntityState.Modified;
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Validation is not complete. You have to call the AddOrUpdateLoadTests method of the Timetable class first.");
            }

            context.SaveChanges();
        }

        public void DeleteById(Guid guid)
        {
            LoadTestingContext context = new LoadTestingContext();
            LoadTest loadTest = context.LoadTests.FirstOrDefault(l => l.Id == guid);
            if (loadTest == null) throw new ArgumentException(String.Format("There's no load test by ID{0}", guid));
            context.Entry<LoadTest>(loadTest).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
