using JFS.DataAccessLayer.Entities;

namespace JFS.DataAccessLayer.Repositories.Abstract
{
    public interface IBalanceRepository
    {
        Balance GetBalance();
        IEnumerable<Entry> GetEntries();
    }
}
