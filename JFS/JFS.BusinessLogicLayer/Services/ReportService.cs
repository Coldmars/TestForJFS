using JFS.BusinessLogicLayer.Builders;
using JFS.BusinessLogicLayer.DTOs;
using JFS.BusinessLogicLayer.Enums;
using JFS.BusinessLogicLayer.Models;
using JFS.BusinessLogicLayer.Services.Abstract;

namespace JFS.BusinessLogicLayer.Services
{
    public class ReportService : IReportService
    {
        private readonly IBalanceService _balanceService;
        private readonly IPaymentService _paymentService;
        private readonly IReportBuilder _builder;

        public ReportService(IBalanceService balanceService,
                             IPaymentService paymentService,
                             IReportBuilder builder)
        {
            _balanceService = balanceService;
            _paymentService = paymentService;
            _builder = builder;
        }

        public IEnumerable<Report> GetReports(int accountId, Period mounthCount)
        {
            var reports = new List<Report>();
            var entries = _balanceService.GetEntriesByAccountId(accountId);

            // Flatten entries - ordered and recalculated entries mapped with full date (not string "YYYYMM")
            var flattenEntries = _balanceService.GetFlattenEntriesFrom(entries);

            for (int i = 0; i < flattenEntries.Count(); i += ((int)mounthCount))
            {
                var period = flattenEntries
                    .Skip(i)
                    .Take(((int)mounthCount))
                    .ToList();

                var report = MakeReportFor(period);

                reports.Add(report);
            }

            reports.Reverse();
            return reports;
        }

        private Report MakeReportFor(IEnumerable<EntryDto> period)
        {
            var inBalance = period.First().InBalance;

            var paidSum = _paymentService
                .GetSumForPeriod(period.First().Period, 
                                 period.Last().Period);

            var calculations = period.Sum(x => x.Calculation);

            var outBalance = inBalance + calculations - paidSum;

            var report = _builder
                .CreateReport(period)
                .SetName()
                .SetInBalance(Math.Round(inBalance, 2))
                .SetCalculations(Math.Round(calculations, 2))
                .SetPaidSum(Math.Round(paidSum, 2))
                .SetOutBalance(Math.Round(outBalance, 2))
                .GetReport();

            return report;
        }
    }
}
