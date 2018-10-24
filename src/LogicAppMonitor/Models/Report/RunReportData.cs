using System;
using System.Collections.Generic;
using System.Text;

namespace LogicAppMonitor.Models.Report
{
    public class RunReportData
    {
        public List<string> HeaderNames { get; set; }
        public List<List<object>> Measurements { get; set; }
    }
}
