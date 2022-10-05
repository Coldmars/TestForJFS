using JFS.DataAccessLayer.Entities;

namespace JFS.BusinessLogicLayer.Services.Abstract
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetPayments();

        double GetSumForMonth(DateTimeOffset monthPeriod);

        double GetSumForPeriod(DateTimeOffset begin,
                               DateTimeOffset end);
    }
}
