using System;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// The LoadTest Entity.
    /// </summary>
    public class LoadTest : EntityBase<Guid>
    {
        /// <summary>
        /// The Guid of the Agent used.
        /// </summary>
        public Guid AgentId { get; private set; }

        /// <summary>
        /// The Guid of the Customer.
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// The Guid of the Engineer, this is not required.
        /// </summary>
        public Guid? EngineerId { get; private set; }

        /// <summary>
        /// The Type of the LoadTest
        /// </summary>
        public Guid LoadTestTypeId { get; private set; }

        /// <summary>
        /// The Guid of the current Project.
        /// </summary>
        public Guid ProjectId { get; private set; }

        /// <summary>
        /// The Guid of the Scenario.
        /// </summary>
        public Guid ScenarioId { get; private set; }

        /// <summary>
        /// The parameters used in this particuliar test.
        /// </summary>
        public LoadTestParameters Parameters { get; private set; }

        /// <summary>
        /// Private parameterless constructor required by EntityFramework.
        /// </summary>
        private LoadTest() : base(Guid.NewGuid()) { }

        /// <summary>
        /// The constructor for the LoadTest.
        /// </summary>
        /// <param name="guid">The LoadTestGuid.</param>
        /// <param name="parameters">The parameters of the loadTest.</param>
        /// <param name="agentId">The agent of the loadTest.</param>
        /// <param name="customerId">The customer of the loadTest.</param>
        /// <param name="engineerId">The facultative engineer of the loadTest.</param>
        /// <param name="loadTestTypeId">The type of the loadTest.</param>
        /// <param name="projectId">The project of the loadTest.</param>
        /// <param name="scenarioId">The scenario of the loadTest.</param>
        public LoadTest(Guid guid, LoadTestParameters parameters, Guid agentId, Guid customerId, Guid? engineerId
            , Guid loadTestTypeId, Guid projectId, Guid scenarioId) : base(guid)
        {
            RaiseIfDefaultGuid(guid);
            AssignParameters(parameters, agentId, customerId, engineerId, loadTestTypeId, projectId, scenarioId);
        }

        /// <summary>
        /// An public method made to assign all the parameters.
        /// </summary>
        /// <param name="parameters">The parameters of the loadTest.</param>
        /// <param name="agentId">The agent of the loadTest.</param>
        /// <param name="customerId">The customer of the loadTest.</param>
        /// <param name="engineerId">The facultative engineer of the loadTest.</param>
        /// <param name="loadTestTypeId">The type of the loadTest.</param>
        /// <param name="projectId">The project of the loadTest.</param>
        /// <param name="scenarioId">The scenario of the loadTest.</param>
        public void Update(LoadTestParameters parameters, Guid agentId, Guid customerId, Guid? engineerId
            , Guid loadTestTypeId, Guid projectId, Guid scenarioId)
        {
            AssignParameters(parameters, agentId, customerId, engineerId, loadTestTypeId, projectId, scenarioId);
        }

        /// <summary>
        /// The internal method assigning all the parameters.
        /// </summary>
        /// <param name="parameters">The parameters of the loadTest.</param>
        /// <param name="agentId">The agent of the loadTest.</param>
        /// <param name="customerId">The customer of the loadTest.</param>
        /// <param name="engineerId">The facultative engineer of the loadTest.</param>
        /// <param name="loadTestTypeId">The type of the loadTest.</param>
        /// <param name="projectId">The project of the loadTest.</param>
        /// <param name="scenarioId">The scenario of the loadTest.</param>
        private void AssignParameters(LoadTestParameters parameters, Guid agentId, Guid customerId, Guid? engineerId
            , Guid loadTestTypeId, Guid projectId, Guid scenarioId)
        {
            RaiseIfDefaultGuid(agentId);
            RaiseIfDefaultGuid(customerId);
            if (engineerId.HasValue) RaiseIfDefaultGuid(engineerId.Value);
            RaiseIfDefaultGuid(loadTestTypeId);
            RaiseIfDefaultGuid(projectId);
            RaiseIfDefaultGuid(scenarioId);

            AgentId = agentId;
            CustomerId = customerId;
            EngineerId = engineerId;
            LoadTestTypeId = loadTestTypeId;
            ProjectId = projectId;
            ScenarioId = scenarioId;
            Parameters = parameters;
        }

        /// <summary>
        /// Check if the Guid send is a default one.
        /// </summary>
        /// <param name="guid">The Guid to test.</param>
        /// <exception cref="ArgumentException">Sent if the guid is a default one.</exception>
        private void RaiseIfDefaultGuid(Guid guid)
        {
            if (guid == default(Guid))
            {
                throw new ArgumentException("Default GUID not acceptable");
            }
        }
    }
}
