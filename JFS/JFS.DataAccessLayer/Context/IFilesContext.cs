using JFS.DataAccessLayer.Entities;

namespace JFS.DataAccessLayer.Context
{
    public interface IFilesContext
    {
        Balance Balance { get; set; }

        IEnumerable<Payment> Payments { get; set; }
    }
}
