using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using LogicAppMonitor;
using LogicAppMonitor.Generators;

namespace ReportGenerator
{

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Parse config and create options
                CreateReportOptions argOptions=null;
                var options = Parser.Default.ParseArguments<CreateReportOptions>(args);
                options.WithParsed(o => argOptions = o);
                var config = GetConfig(argOptions.SectionId);

                // Call API and extract data
                var dataExtractor = new ReportDataExtractor();
                var reportData = dataExtractor.ExtractData(config, argOptions.MaxResults).Result;

                // Generate report
                IReportGenerator generator = new CsvGenerator();
                generator.Generate(reportData, $@"{argOptions.OutputDirectory}\results-{DateTime.Now:yyyyMMddHHmmss}.csv").Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        

        private static LogicAppConfig GetConfig(string sectionId)
        {
            if (ConfigurationManager.GetSection(LogicAppsDataSection.SectionName) is LogicAppsDataSection logicAppsDataSection)
            {
                foreach (LogicAppsEndpointElement endpointElement in logicAppsDataSection.LogicAppsEndpoints)
                {
                    if (endpointElement.Name.Equals(sectionId))
                    {
                        return new LogicAppConfig
                        {
                            ClientId = endpointElement.ClientId,
                            ClientSecret = endpointElement.ClientSecret,
                            SubscriptionId = endpointElement.SubscriptionId,
                            TenantId = endpointElement.TenantId,
                            ResourceGroupName = endpointElement.ResourceGroup,
                            WorkflowName = endpointElement.WorkflowName
                        }; 
                    }
                }
            }

            throw new ApplicationException($"The section {sectionId} was not found in the exe.config");
        }


    }
}



