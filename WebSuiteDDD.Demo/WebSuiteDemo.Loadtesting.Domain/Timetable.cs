using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class Timetable : IAggregateRoot
    {
        public IList<LoadTest> LoadTests { get; private set; }

        public Timetable(IList<LoadTest> loadTests)
        {
            if (loadTests == null) loadTests = new List<LoadTest>();
            LoadTests = loadTests;
        }

        public AddOrUpdateLoadTestsValidationResult AddOrUpdateLoadTests(IList<LoadTest> loadTestsAddedOrUpdated)
        {
            List<LoadTest> toBeInserted = new List<LoadTest>();
            List<LoadTest> toBeUpdated = new List<LoadTest>();
            List<LoadTest> failed = new List<LoadTest>();
            StringBuilder resultSummaryBuilder = new StringBuilder();
            string NL = Environment.NewLine;
            foreach (LoadTest loadtest in loadTestsAddedOrUpdated)
            {
                LoadTest existing = LoadTests.FirstOrDefault(l => l.Id == loadtest.Id);
                if (existing != null)
                {
                    LoadTestValidationSummary validationSummary = OkToAddOrModify(loadtest);
                    if (validationSummary.OkToAddOrModify)
                    {
                        existing.Update
                            (loadtest.Parameters, loadtest.AgentId, loadtest.CustomerId, loadtest.EngineerId,
                            loadtest.LoadTestTypeId, loadtest.ProjectId, loadtest.ScenarioId);
                        toBeUpdated.Add(existing);
                        resultSummaryBuilder.Append(string.Format("Load test ID {0} (update) successfully validated.{1}", existing.Id, NL));
                    }
                    else
                    {
                        failed.Add(loadtest);
                        resultSummaryBuilder.Append(string.Format("Loaf test ID {0} (update) validation failed: {1}{2}.",
                            existing.Id, validationSummary.ReasonForValidationFailure, NL));
                    }
                }
                else
                {
                    LoadTestValidationSummary validationSummary = OkToAddOrModify(loadtest);
                    if (validationSummary.OkToAddOrModify)
                    {
                        LoadTests.Add(loadtest);
                        toBeInserted.Add(loadtest);
                        resultSummaryBuilder.Append(string.Format("Load test ID {0} (insertion) successfully validated.{1}", loadtest.Id, NL));
                    }
                    else
                    {
                        failed.Add(loadtest);
                        resultSummaryBuilder.Append(string.Format("Load test ID {0} (insertion) validation failed: {1}{2}.",
                            loadtest.Id, validationSummary.ReasonForValidationFailure, NL));
                    }
                }

            }

            return new AddOrUpdateLoadTestsValidationResult(toBeInserted, toBeUpdated, failed, resultSummaryBuilder.ToString());
        }

        private LoadTestValidationSummary OkToAddOrModify(LoadTest loadTest)
        {
            LoadTestValidationSummary validationSummary = new LoadTestValidationSummary();
            validationSummary.OkToAddOrModify = true;
            validationSummary.ReasonForValidationFailure = string.Empty;
            List<LoadTest> loadtestsOnSameAgent = LoadTests.Where(l => l.AgentId == loadTest.AgentId
                && DatesOverlap(l, loadTest)).ToList();

            if (loadtestsOnSameAgent.Count >= 2)
            {
                validationSummary.OkToAddOrModify = false;
                validationSummary.ReasonForValidationFailure += "The selected load test agent is already booked for this period.";
            }

            if (loadTest.EngineerId.HasValue)
            {
                List<LoadTest> loadtestsOnSameEngineer = LoadTests.Where(l => l.EngineerId.Value == loadTest.EngineerId.Value
                    && DatesOverlap(l, loadTest)).ToList();

                if (loadtestsOnSameEngineer.Any())
                {
                    validationSummary.OkToAddOrModify = false;
                    validationSummary.ReasonForValidationFailure += "The selected load test engineer is already booked for this period.";
                }
            }

            return validationSummary;
        }

        private bool DatesOverlap(LoadTest loadtestOne, LoadTest loadtestTwo)
        {
            return (loadtestOne.Parameters.StartDateUtc < loadtestTwo.Parameters.GetEndDateUtc()
                && loadtestTwo.Parameters.StartDateUtc < loadtestOne.Parameters.GetEndDateUtc());
        }
    }
}
