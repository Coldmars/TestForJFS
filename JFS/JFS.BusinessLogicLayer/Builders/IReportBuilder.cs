using JFS.BusinessLogicLayer.DTOs;
using JFS.BusinessLogicLayer.Models;

namespace JFS.BusinessLogicLayer.Builders
{
    public interface IReportBuilder
    {
        ReportBuilder CreateReport(IEnumerable<EntryDto> balances);

        ReportBuilder SetName();

        ReportBuilder SetInBalance(double inBalance);

        ReportBuilder SetCalculations(double calculations);

        ReportBuilder SetPaidSum(double sum);

        ReportBuilder SetOutBalance(double outBalance);

        Report GetReport();
    }
}
