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
	}
}
