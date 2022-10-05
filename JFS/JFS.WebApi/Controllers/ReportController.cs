using JFS.BusinessLogicLayer.Enums;
using JFS.BusinessLogicLayer.Models;
using JFS.BusinessLogicLayer.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JFS.WebApi.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Report> GetBalances(int accountId, Period period)
        {
            return _service.GetReports(accountId, period);
        }
    }
}
