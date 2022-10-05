using JFS.BusinessLogicLayer.DTOs;
using JFS.DataAccessLayer.Entities;

namespace JFS.BusinessLogicLayer.Services.Abstract
{
    public interface IBalanceService
    {
        Balance GetBalance();

        IEnumerable<Entry> GetAllEntries();

        IEnumerable<Entry> GetEntriesByAccountId(int accountId);

        IEnumerable<EntryDto> GetFlattenEntriesFrom(IEnumerable<Entry> entries);
    }
}
