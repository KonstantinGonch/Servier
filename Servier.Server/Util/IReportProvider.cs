using Servier.Server.Controllers;
using Servier.Server.Models;

namespace Servier.Server.Util
{
	public interface IReportProvider
	{
		IEnumerable<SalesItem> GetReportSalesItems();
		IEnumerable<SalesIncreaseReportItem> GetSalesIncreaseReport(DivisionType divisionType);
		IEnumerable<ReportItemIncreaseByYears> GetYearlyIncreaseReportData(string byItem, string byShop);
	}
}
