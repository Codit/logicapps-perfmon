using System;

namespace LogicAppMonitor.Models.Actions
{
    public class Properties
    {
        public Inputslink inputsLink { get; set; }
        public Outputslink outputsLink { get; set; }
        public Trackedproperties trackedProperties { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Correlation correlation { get; set; }
        public string status { get; set; }
        public string code { get; set; }
    }
}