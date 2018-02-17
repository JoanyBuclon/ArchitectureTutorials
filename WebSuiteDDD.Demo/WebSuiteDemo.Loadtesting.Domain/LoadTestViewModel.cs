using System;

namespace WebSuiteDemo.Loadtesting.Domain
{
    public class LoadTestViewModel
    {
        public Guid Id { get; set; }
        public string AgentCity { get; set; }
        public string AgentCountry { get; set; }
        public string CustomerName { get; set; }
        public string EngineerName { get; set; }
        public string LoadTestTypeShortDescription { get; set; }
        public string ProjectName { get; set; }
        public string ScenarioUriOne { get; set; }
        public string ScenarioUriTwo { get; set; }
        public string ScenarioUriThree { get; set; }
        public DateTime StartDateUtc { get; set; }
        public int UserCount { get; set; }
        public int DurationSec { get; set; }
    }
}
