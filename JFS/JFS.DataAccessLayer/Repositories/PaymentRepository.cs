using JFS.DataAccessLayer.Context;
using JFS.DataAccessLayer.Entities;
using JFS.DataAccessLayer.Repositories.Abstract;

namespace JFS.DataAccessLayer.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IFilesContext _context;

        public PaymentRepository(IFilesContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _context.Payments;
        }
    }
}
