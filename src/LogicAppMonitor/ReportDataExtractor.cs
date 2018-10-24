using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicAppMonitor.Models.Report;

namespace LogicAppMonitor
{
    public class ReportDataExtractor
    {
        public async Task<RunReportData> ExtractData(LogicAppConfig config, int maxResults)
        {
            var runMonitor = new RunMonitor();
            var latestRuns = await (runMonitor.ListRuns(maxResults, config));

            var runSequenceNr = 0;
            var reportData = new RunReportData {Measurements = new List<List<object>>()};
            foreach (var run in latestRuns.value)
            {
                var headerNames = new List<string> { "Number", "WorkflowStart", "WorkflowDuration" };
                var currentRunData = new List<object>
                {
                    ++runSequenceNr, // sequence nr
                    run.properties.startTime, // start time
                    CalculateDuration(run.properties.startTime, run.properties.endTime) // total workflow duration
                };
                // Reading data from API
                var response = await runMonitor.ListActions(run.name, config);
                var actionSequenceNr = 0;

                // Maintain previous time, to calculate initial lag
                var previousEndTime = run.properties.startTime;
                // Sort by time !
                foreach (var action in response.value.OrderBy(ac => ac.properties.startTime))
                {
                    headerNames.Add($"Lag_{actionSequenceNr++:000}");   // add lag title
                    headerNames.Add("{action.name}_Duration;");         // add duration of action
                    currentRunData.Add(CalculateDuration(previousEndTime, action.properties.startTime));    // calculate lag
                    currentRunData.Add(CalculateDuration(action.properties.startTime, action.properties.endTime));  // calculate action time
                    previousEndTime = action.properties.endTime; // keep previous time for lag calculation
                }

                if (reportData.HeaderNames == null) reportData.HeaderNames = headerNames;
                reportData.Measurements.Add(currentRunData);
            }

            return reportData;
        }

        private static double CalculateDuration(DateTime start, DateTime stop)
        {
            return stop.Subtract(start).TotalMilliseconds;
        }
    }
}

