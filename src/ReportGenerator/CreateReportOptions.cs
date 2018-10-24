using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace ReportGenerator
{

    [Verb("create-report", HelpText = "Create report with perf statistics.")]
    public class CreateReportOptions 
    {
        [Option('i', "sectionid", Required = true,
            HelpText = "The id of the config section in the app.config with all settings.")]
        public string SectionId { get; set; }

        [Option('m', "maxresults", Required = false, Default = 50,
            HelpText = "The maximum number of runs to retrieve")]
        public int MaxResults{ get; set; }


        [Option('d', "dir", Required = false, 
            HelpText = "The directory where the report will be stored")]
        public string OutputDirectory { get; set; }

    }
}
