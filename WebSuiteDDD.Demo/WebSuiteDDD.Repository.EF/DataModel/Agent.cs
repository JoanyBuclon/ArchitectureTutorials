using System;

namespace WebSuiteDDD.Repository.EF.DataModel
{
    public class Agent
    {
        public Guid Id { get; set; }
        public Location Location { get; set; }
    }
}
