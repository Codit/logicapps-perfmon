using System;

namespace LogicAppMonitor.Models.Runs
{
    public class Trigger
    {
        public string name { get; set; }
        public Inputslink inputsLink { get; set; }
        public Outputslink outputsLink { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Correlation correlation { get; set; }
        public string status { get; set; }
    }
}