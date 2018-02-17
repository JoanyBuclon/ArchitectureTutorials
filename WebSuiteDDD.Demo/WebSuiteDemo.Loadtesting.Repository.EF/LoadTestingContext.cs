using System.Data.Entity;
using WebSuiteDemo.Loadtesting.Domain;

namespace WebSuiteDemo.Loadtesting.Repository.EF
{
    public class LoadTestingContext : DbContext
    {
        public LoadTestingContext() : base("WebSuiteContext") { }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<LoadTest> LoadTests { get; set; }
        public DbSet<LoadTestType> LoadTestTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
    }
}
