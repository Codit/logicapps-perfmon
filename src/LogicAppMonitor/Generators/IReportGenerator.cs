using System.Threading.Tasks;
using LogicAppMonitor.Models.Report;

namespace LogicAppMonitor.Generators
{
    public interface IReportGenerator
    {
        Task Generate(RunReportData reportData, string fileName);
    }
}
