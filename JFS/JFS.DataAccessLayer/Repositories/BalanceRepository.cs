using JFS.DataAccessLayer.Context;
using JFS.DataAccessLayer.Entities;
using JFS.DataAccessLayer.Repositories.Abstract;

namespace JFS.DataAccessLayer.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly IFilesContext _context;

        public BalanceRepository(IFilesContext context)
        {
            _context = context;
        }

        public Balance GetBalance()
        {
            return _context.Balance;
        }

        public IEnumerable<Entry> GetEntries()
        {
            return _context.Balance.Entries;
        }
    }
}
