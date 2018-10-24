using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogicAppMonitor.Models.Actions;
using LogicAppMonitor.Models.Runs;
using Newtonsoft.Json;

namespace LogicAppMonitor
{
    public class RunMonitor : LogicAppClient
    {
        public async Task<RunQueryResult> ListRuns(int maxResults, LogicAppConfig config)
        {
            var queryResult = await Execute("runs", new Dictionary<string, object> {{"$top", maxResults}}, config);
            return JsonConvert.DeserializeObject<RunQueryResult>(queryResult);
        }

        public async Task<ActionQueryResult> ListActions(string runId, LogicAppConfig config)
        {
            var queryResult = await Execute($"runs/{runId}/actions", new Dictionary<string, object> {  }, config);
            //System.IO.File.WriteAllText($"c:\\temp\\bulk-runactions-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.json", queryResult);
            return JsonConvert.DeserializeObject<ActionQueryResult>(queryResult);
        }
    }
}
