using System;

namespace LogicAppMonitor.Models.Runs
{
    public class Properties
    {
        public DateTime waitEndTime { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string status { get; set; }
        public Correlation correlation { get; set; }
        public Workflow workflow { get; set; }
        public Trigger trigger { get; set; }
        public Outputs outputs { get; set; }
    }
}