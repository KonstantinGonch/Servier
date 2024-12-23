using Microsoft.AspNetCore.Mvc;
using Servier.Server.Models;
using Servier.Server.Util;

namespace Servier.Server.Controllers
{
	[ApiController]
	[Route("api/reports")]
	public class ReportsController : ControllerBase
	{
		private IReportProvider _reportProvider;

		public ReportsController(IReportProvider reportProvider)
		{
			this._reportProvider = reportProvider;
		}

		[HttpGet]
		[Route("getReport")]
		public async Task<IEnumerable<SalesItem>> GetReport()
		{
			var report = _reportProvider.GetReportSalesItems();
			return report;
		}

		[HttpGet]
		[Route("getSalesIncrease")]
		public async Task<IEnumerable<SalesIncreaseReportItem>> GetSalesIncreaseReport([FromQuery] DivisionType divisionType)
		{
			var report = _reportProvider.GetSalesIncreaseReport(divisionType);
			return report;
		}

		[HttpGet]
		[Route("getYearlyIncrease")]
		public async Task<IEnumerable<ReportItemIncreaseByYears>> GetYearlyIncreaseReport([FromQuery] string byItem, [FromQuery] string byShop)
		{
			var report = _reportProvider.GetYearlyIncreaseReportData(byItem, byShop);
			return report;
		}
	}
}
