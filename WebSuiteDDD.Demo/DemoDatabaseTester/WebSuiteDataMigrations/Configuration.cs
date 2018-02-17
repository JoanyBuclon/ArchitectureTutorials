namespace DemoDatabaseTester.WebSuiteDataMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using WebSuiteDDD.Repository.EF;
    using WebSuiteDDD.Repository.EF.DataModel;

    internal sealed class Configuration : DbMigrationsConfiguration<WebSuiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"WebSuiteDataMigrations";
        }

        protected override void Seed(WebSuiteContext context)
        {
            //Some default agents
            List<Agent> agents = new List<Agent>();
            Agent amazon = new Agent();
            amazon.Id = Guid.NewGuid();
            amazon.Location = new Location()
            {
                City = "Seattle",
                Country = "USA",
                Latitude = 123.345,
                Longitude = 135.543
            };
            Agent rackspace = new Agent();
            rackspace.Id = Guid.NewGuid();
            rackspace.Location = new Location()
            {
                City = "Frankfurt",
                Country = "Germany",
                Latitude = -123.654,
                Longitude = 121.321
            };
            Agent azure = new Agent();
            azure.Id = Guid.NewGuid();
            azure.Location = new Location()
            {
                City = "Tokyo",
                Country = "Japan",
                Latitude = 23.45,
                Longitude = 12.343
            };
            agents.Add(amazon);
            agents.Add(rackspace);
            agents.Add(azure);
            context.Agents.AddRange(agents);

            //Some Customers
            List<Customer> customers = new List<Customer>();
            Customer niceCustomer = new Customer();
            niceCustomer.Id = Guid.NewGuid();
            niceCustomer.Address = "New York";
            niceCustomer.MainContact = "Elvis Presley";
            niceCustomer.Name = "Nice customer";

            Customer greatCustomer = new Customer();
            greatCustomer.Id = Guid.NewGuid();
            greatCustomer.Address = "London";
            greatCustomer.MainContact = "Phil Collins";
            greatCustomer.Name = "Great customer";

            Customer okCustomer = new Customer();
            okCustomer.Id = Guid.NewGuid();
            okCustomer.Address = "Berlin";
            okCustomer.MainContact = "Freddie Mercury";
            okCustomer.Name = "OK Customer";

            customers.Add(niceCustomer);
            customers.Add(greatCustomer);
            customers.Add(okCustomer);
            context.Customers.AddRange(customers);

            //Some Engineers
            List<Engineer> engineers = new List<Engineer>();
            Engineer john = new Engineer();
            john.Id = Guid.NewGuid();
            john.Name = "John";
            john.Title = "Load test engineer";
            john.YearJoinedCompany = 2013;

            Engineer mary = new Engineer();
            mary.Id = Guid.NewGuid();
            mary.Name = "Mary";
            mary.Title = "Sr. load test engineer";
            mary.YearJoinedCompany = 2012;

            Engineer fred = new Engineer();
            fred.Id = Guid.NewGuid();
            fred.Name = "Fred";
            fred.Title = "Jr. load test engineer";
            fred.YearJoinedCompany = 2014;

            engineers.Add(john);
            engineers.Add(mary);
            engineers.Add(fred);
            context.Engineers.AddRange(engineers);

            //Some TestTypes
            List<LoadTestType> testTypes = new List<LoadTestType>();
            LoadTestType stressTest = new LoadTestType();
            stressTest.Id = Guid.NewGuid();
            stressTest.Description = new Description()
            {
                ShortDescription = "Stress test",
                LongDescription = "To determine or validate an application’s behavior when it is pushed beyond normal or peak load conditions."
            };

            LoadTestType capacityTest = new LoadTestType();
            capacityTest.Id = Guid.NewGuid();
            capacityTest.Description = new Description()
            {
                ShortDescription = "Capacity test",
                LongDescription = "To determine how many users and/or transactions a given system will support and still meet performance goals."
            };

            testTypes.Add(stressTest);
            testTypes.Add(capacityTest);
            context.LoadTestTypes.AddRange(testTypes);

            //Some projects
            List<Project> projects = new List<Project>();
            Project firstProject = new Project();
            firstProject.Id = Guid.NewGuid();
            firstProject.DateInsertedUtc = DateTime.UtcNow;
            firstProject.Description = new Description()
            {
                ShortDescription = "First project",
                LongDescription = "Long description of first project"
            };

            Project secondProject = new Project();
            secondProject.Id = Guid.NewGuid();
            secondProject.DateInsertedUtc = DateTime.UtcNow.AddDays(-5);
            secondProject.Description = new Description()
            {
                ShortDescription = "Second project",
                LongDescription = "Long description of second project"
            };

            Project thirdProject = new Project();
            thirdProject.Id = Guid.NewGuid();
            thirdProject.DateInsertedUtc = DateTime.UtcNow.AddDays(-10);
            thirdProject.Description = new Description()
            {
                ShortDescription = "Third project",
                LongDescription = "Long description of third project"
            };
            projects.Add(firstProject);
            projects.Add(secondProject);
            projects.Add(thirdProject);
            context.Projects.AddRange(projects);

            //Some Scenarios
            List<Scenario> scenarios = new List<Scenario>();
            Scenario scenarioOne = new Scenario();
            scenarioOne.Id = Guid.NewGuid();
            scenarioOne.UriOne = "www.bbc.co.uk";
            scenarioOne.UriTwo = "www.cnn.com";

            Scenario scenarioTwo = new Scenario();
            scenarioTwo.Id = Guid.NewGuid();
            scenarioTwo.UriOne = "www.amazon.com";
            scenarioTwo.UriTwo = "www.microsoft.com";

            Scenario scenarioThree = new Scenario();
            scenarioThree.Id = Guid.NewGuid();
            scenarioThree.UriOne = "www.greatsite.com";
            scenarioThree.UriTwo = "www.nosuchsite.com";
            scenarioThree.UriThree = "www.neverheardofsite.com";

            scenarios.Add(scenarioOne);
            scenarios.Add(scenarioTwo);
            scenarios.Add(scenarioThree);
            context.Scenarios.AddRange(scenarios);

            //Some LoadTests
            List<LoadTest> loadtests = new List<LoadTest>();
            LoadTest ltOne = new LoadTest();
            ltOne.Id = Guid.NewGuid();
            ltOne.AgentId = amazon.Id;
            ltOne.CustomerId = niceCustomer.Id;
            ltOne.EngineerId = john.Id;
            ltOne.LoadTestTypeId = stressTest.Id;
            ltOne.Parameters = new LoadTestParameters() { DurationSec = 60, StartDateUtc = DateTime.UtcNow, UserCount = 10 };
            ltOne.ProjectId = firstProject.Id;
            ltOne.ScenarioId = scenarioOne.Id;

            LoadTest ltTwo = new LoadTest();
            ltTwo.Id = Guid.NewGuid();
            ltTwo.AgentId = azure.Id;
            ltTwo.CustomerId = greatCustomer.Id;
            ltTwo.EngineerId = mary.Id;
            ltTwo.LoadTestTypeId = capacityTest.Id;
            ltTwo.Parameters = new LoadTestParameters() { DurationSec = 120, StartDateUtc = DateTime.UtcNow.AddMinutes(20), UserCount = 40 };
            ltTwo.ProjectId = secondProject.Id;
            ltTwo.ScenarioId = scenarioThree.Id;

            LoadTest ltThree = new LoadTest();
            ltThree.Id = Guid.NewGuid();
            ltThree.AgentId = rackspace.Id;
            ltThree.CustomerId = okCustomer.Id;
            ltThree.EngineerId = fred.Id;
            ltThree.LoadTestTypeId = stressTest.Id;
            ltThree.Parameters = new LoadTestParameters() { DurationSec = 180, StartDateUtc = DateTime.UtcNow.AddMinutes(30), UserCount = 50 };
            ltThree.ProjectId = thirdProject.Id;
            ltThree.ScenarioId = scenarioTwo.Id;

            loadtests.Add(ltOne);
            loadtests.Add(ltTwo);
            loadtests.Add(ltThree);
            context.LoadTests.AddRange(loadtests);

            context.SaveChanges();
        }
    }
}
