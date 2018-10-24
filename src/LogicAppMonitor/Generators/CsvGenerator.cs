using System.IO;
using System.Text;
using System.Threading.Tasks;
using LogicAppMonitor.Models.Report;

namespace LogicAppMonitor.Generators
{
    public class CsvGenerator : IReportGenerator
    {
        public async Task Generate(RunReportData reportData, string fileName)
        {
            using (var csvWriter = new StreamWriter(new FileStream(
                fileName, FileMode.CreateNew,
                FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                foreach (var headerName in reportData.HeaderNames)
                {
                    await csvWriter.WriteAsync($"{headerName};");
                }
                await csvWriter.WriteLineAsync();
                foreach (var measurement in reportData.Measurements)
                {
                    foreach (var value in measurement)
                    {
                        await csvWriter.WriteAsync($"{value};");
                    }
                    await csvWriter.WriteLineAsync();
                }
                await csvWriter.FlushAsync();
                csvWriter.Close();
            }
        }
    }
}
