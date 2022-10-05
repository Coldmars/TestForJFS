using JFS.DataAccessLayer.Entities;

namespace JFS.DataAccessLayer.Repositories.Abstract
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetPayments();
    }
}
