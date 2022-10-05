using JFS.BusinessLogicLayer.Services.Abstract;
using JFS.DataAccessLayer.Entities;
using JFS.DataAccessLayer.Repositories.Abstract;

namespace JFS.BusinessLogicLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _paymentRepository.GetPayments();
        }

        public double GetSumForMonth(DateTimeOffset monthPeriod)
        {
            var sum = _paymentRepository
                .GetPayments()
                .Where(p => p.Date.Year == monthPeriod.Year &&
                            p.Date.Month == monthPeriod.Month)
                .Sum(p => p.Sum);

            return sum;
        }

        public double GetSumForPeriod(DateTimeOffset begin,
                                      DateTimeOffset end)
        {
            var sum = _paymentRepository
                .GetPayments()
                .Where(p => p.Date >= begin &&
                            p.Date <= end.AddMonths(1))
                .Sum(p => p.Sum);

            return sum;
        }
    }
}
