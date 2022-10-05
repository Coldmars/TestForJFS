using JFS.BusinessLogicLayer.DTOs;
using JFS.BusinessLogicLayer.Models;

namespace JFS.BusinessLogicLayer.Builders
{
    public class ReportBuilder : IReportBuilder
    {
        private Report _report;
        private IEnumerable<EntryDto> _balances;

        public ReportBuilder()
        {
            _report = null;
            _balances = null;
        }

        public ReportBuilder CreateReport(IEnumerable<EntryDto> balances)
        {
            _report = new Report();
            _balances = balances;

            return this;
        }

        public ReportBuilder SetName()
        {
            string begin = _balances.First().Period.ToString("yyyyMM");
            string end = _balances.Last().Period.ToString("yyyyMM");

            _report.Name = begin + " - " + end;

            return this;
        }

        public ReportBuilder SetInBalance(double inBalance)
        {
            _report.InBalance = inBalance;

            return this;
        }

        public ReportBuilder SetCalculations(double calculations)
        {
            _report.Calculation = calculations;

            return this;
        }

        public ReportBuilder SetPaidSum(double sum)
        {
            _report.PaidSum = sum;

            return this;
        }

        public ReportBuilder SetOutBalance(double outBalance)
        {
            _report.OutBalance = outBalance;

            return this;
        }

        public Report GetReport() => _report;
        
    }
}
