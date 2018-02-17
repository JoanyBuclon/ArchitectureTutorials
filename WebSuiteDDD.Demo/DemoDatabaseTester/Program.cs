namespace DemoDatabaseTester
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadTestingContextService domainService = new LoadTestingContextService();
            domainService.TestLoadTestingContext();

            //WebSuiteContext context = new WebSuiteContext();
            //List<Agent> dbAgents = context.Agents.ToList();
            //foreach (Agent agent in dbAgents)
            //{
            //    Debug.WriteLine(string.Format("Agent ID: {0}, city: {1}, country: {2}", agent.Id, agent.Location.City, agent.Location.Country));
            //}

            //Engineer dbEngineer = new Engineer();
            //dbEngineer.Id = Guid.NewGuid();
            //dbEngineer.Name = null; //Jane
            //dbEngineer.Title = "Jr. Load test engineer";
            //dbEngineer.YearJoinedCompany = 2012;
            //context.Engineers.Add(dbEngineer);
            //context.SaveChanges();
        }
    }
}
