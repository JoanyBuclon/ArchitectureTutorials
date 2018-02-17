using System;

namespace WebSuiteDDD.Repository.EF.DataModel
{
    public class LoadTestParameters
    {
        public DateTime StartDateUtc { get; set; }
        public int UserCount { get; set; }
        public int DurationSec { get; set; }
    }
}
