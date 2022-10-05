using JFS.BusinessLogicLayer.Enums;
using JFS.BusinessLogicLayer.Models;

namespace JFS.BusinessLogicLayer.Services.Abstract
{
    public interface IReportService
    {
        IEnumerable<Report> GetReports(int accountId, Period mounthCount);
    }
}
