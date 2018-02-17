using System;

namespace WebSuiteDDD.Repository.EF.DataModel
{
    public class LoadTest
    {
        public Guid Id { get; set; }
        public Guid AgentId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? EngineerId { get; set; }
        public Guid LoadTestTypeId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ScenarioId { get; set; }
        public LoadTestParameters Parameters { get; set; }
    }
}
