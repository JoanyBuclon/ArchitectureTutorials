using System;
using System.Collections.Generic;
using System.Linq;
using WebSuiteDemo.Loadtesting.Domain;

namespace WebSuiteDemo.Loadtesting.Repository.EF.Repositories
{
    public class TimetableViewModelRepository : ITimetableViewModelRepository
    {
        public IList<LoadTestViewModel> ConvertToViewModel(IEnumerable<LoadTest> domains)
        {
            LoadTestingContext context = new LoadTestingContext();
            List<LoadTestViewModel> viewModels = new List<LoadTestViewModel>();
            foreach (LoadTest lt in domains)
            {
                LoadTestViewModel vm = new LoadTestViewModel();
                vm.Id = lt.Id;

                Agent agent = context.Agents.FirstOrDefault(a => a.Id == lt.Id);
                if (agent == null) throw new ArgumentException("There is no load test agent with the given ID.");
                vm.AgentCountry = agent.Location.Country;
                vm.AgentCity = agent.Location.City;

                Customer customer = context.Customers.FirstOrDefault(c => c.Id == lt.CustomerId);
                if (customer == null) throw new ArgumentException("There is no customer with the given ID.");
                vm.CustomerName = customer.Name;

                if (lt.EngineerId.HasValue)
                {
                    Engineer engineer = context.Engineers.FirstOrDefault(e => e.Id == lt.EngineerId.Value);
                    if (engineer == null) throw new ArgumentException("There is no engineer with the given ID.");
                    vm.EngineerName = engineer.Name;
                }

                LoadTestType loadTestType = context.LoadTestTypes.FirstOrDefault(t => t.Id == lt.LoadTestTypeId);
                if (loadTestType == null) throw new ArgumentException("There is no load test type with the given ID.");
                vm.LoadTestTypeShortDescription = loadTestType.Description.ShortDescription;

                Project project = context.Projects.FirstOrDefault(p => p.Id == lt.ProjectId);
                if (project == null) throw new ArgumentException("There is no project with the given ID.");
                vm.ProjectName = project.Description.ShortDescription;

                Scenario scenario = context.Scenarios.FirstOrDefault(s => s.Id == lt.ScenarioId);
                if (scenario == null) throw new ArgumentException("There is no scenario with the given ID.");
                vm.ScenarioUriOne = scenario.UriOne;
                vm.ScenarioUriTwo = scenario.UriTwo;
                vm.ScenarioUriThree = scenario.UriThree;

                vm.UserCount = lt.Parameters.UserCount;
                vm.StartDateUtc = lt.Parameters.StartDateUtc;
                vm.DurationSec = lt.Parameters.DurationSec;

                viewModels.Add(vm);
            }

            return viewModels;
        }

        public IList<LoadTest> ConvertToDomain(IEnumerable<LoadTestViewModel> viewModels)
        {
            List<LoadTest> loadtests = new List<LoadTest>();
            LoadTestingContext context = new LoadTestingContext();
            foreach (LoadTestViewModel vm in viewModels)
            {
                Guid id = vm.Id;
                LoadTestParameters ltParams = new LoadTestParameters(vm.StartDateUtc, vm.UserCount, vm.DurationSec);
                Agent agent = context.Agents.FirstOrDefault(a => a.Location.City.Equals(vm.AgentCity, StringComparison.InvariantCultureIgnoreCase)
                    && a.Location.Country.ToLower() == vm.AgentCountry.ToLower());
                if (agent == null) throw new ArgumentException("There is no agent with the given properties.");

                Customer customer = context.Customers.FirstOrDefault(c => c.Name.Equals(vm.CustomerName, StringComparison.InvariantCultureIgnoreCase));
                if (customer == null) throw new ArgumentException("There is no customer with the given name.");

                Guid? engineerId = null;
                if (!string.IsNullOrEmpty(vm.EngineerName))
                {
                    Engineer engineer = context.Engineers.FirstOrDefault(e => e.Name.Equals(vm.EngineerName, StringComparison.InvariantCultureIgnoreCase));
                    if (engineer == null) throw new ArgumentException("There is no engineer with the given properties.");
                    engineerId = engineer.Id;
                }

                LoadTestType ltType = context.LoadTestTypes.FirstOrDefault(t => t.Description.ShortDescription.Equals(vm.LoadTestTypeShortDescription, StringComparison.InvariantCultureIgnoreCase));
                if (ltType == null) throw new ArgumentException("There is no load test type with the given properties.");

                Project project = context.Projects.FirstOrDefault(p => p.Description.ShortDescription.ToLower() == vm.ProjectName.ToLower());
                if (project == null) throw new ArgumentException("There is no project with the given properties.");

                Scenario scenario = context.Scenarios.FirstOrDefault(s => s.UriOne.Equals(vm.ScenarioUriOne, StringComparison.InvariantCultureIgnoreCase)
                    && s.UriTwo.Equals(vm.ScenarioUriTwo, StringComparison.InvariantCultureIgnoreCase) && s.UriThree.Equals(vm.ScenarioUriThree, StringComparison.InvariantCultureIgnoreCase));

                if (scenario == null)
                {
                    List<Uri> uris = new List<Uri>();
                    Uri firstUri = string.IsNullOrEmpty(vm.ScenarioUriOne) ? null : new Uri(vm.ScenarioUriOne);
                    Uri secondUri = string.IsNullOrEmpty(vm.ScenarioUriTwo) ? null : new Uri(vm.ScenarioUriTwo);
                    Uri thirdUri = string.IsNullOrEmpty(vm.ScenarioUriThree) ? null : new Uri(vm.ScenarioUriThree);

                    if (firstUri != null) uris.Add(firstUri);
                    if (secondUri != null) uris.Add(secondUri);
                    if (thirdUri != null) uris.Add(thirdUri);

                    scenario = new Scenario(Guid.NewGuid(), uris);
                    context.Scenarios.Add(scenario);
                    context.SaveChanges();
                }

                LoadTest converted = new LoadTest(id, ltParams, agent.Id, customer.Id, engineerId, ltType.Id, project.Id, scenario.Id);
                loadtests.Add(converted);
            }

            return loadtests;
        }
    }
}
