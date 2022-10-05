using AutoMapper;
using JFS.BusinessLogicLayer.DTOs;
using JFS.BusinessLogicLayer.Services.Abstract;
using JFS.DataAccessLayer.Entities;
using JFS.DataAccessLayer.Repositories.Abstract;

namespace JFS.BusinessLogicLayer.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public BalanceService(IBalanceRepository balanceRepository, 
                              IPaymentRepository paymentRepository,
                              IPaymentService paymentService,
                              IMapper mapper)
        {
            _balanceRepository = balanceRepository;
            _paymentRepository = paymentRepository;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public Balance GetBalance()
        {
            return _balanceRepository.GetBalance();
        }

        public IEnumerable<Entry> GetAllEntries()
        {
            return _balanceRepository.GetEntries();
        }

        public IEnumerable<Entry> GetEntriesByAccountId(int accountId)
        {
            var entries = _balanceRepository
                .GetEntries()
                .Where(e => e.AccountId == accountId);

            return entries;
        }

        // Flatten entries - ordered and recalculated entries mapped with full date
        public IEnumerable<EntryDto> GetFlattenEntriesFrom(IEnumerable<Entry> entries)
        {
            var entriesDto = _mapper.Map<IEnumerable<EntryDto>>(entries);
            var orderedEntriesDto = entriesDto
                .OrderBy(x => x.Period)
                .ToList();

            var flattenEntries = GetRecalculatedFrom(orderedEntriesDto);

            return flattenEntries;
        }

        private IEnumerable<EntryDto> GetRecalculatedFrom(List<EntryDto> entries)
        {
            // Idea: InBalance[current] = InBalance[prev] + Calculation[prev] - PaidSum[prev]

            for (int i = 0; i < entries.Count; i++)
            {
                double incomingBalance;

                var currentEntry = entries[i];
                var currentSum = _paymentService.GetSumForMonth(currentEntry.Period);


                if (i == 0)
                {
                    var nextEntry = entries[i + 1];

                    incomingBalance = nextEntry.InBalance - currentEntry.Calculation + currentSum;

                    entries[i].InBalance = Math.Round(incomingBalance, 2);

                    continue;
                }

                var prevEntry = entries[i - 1];
                var prevSum = _paymentService.GetSumForMonth(prevEntry.Period);

                incomingBalance = prevEntry.InBalance + prevEntry.Calculation - prevSum;

                entries[i].InBalance = Math.Round(incomingBalance, 2);
            }

            return entries;
        }
    }
}
