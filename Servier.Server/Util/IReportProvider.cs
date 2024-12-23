using Servier.Server.Models;

namespace Servier.Server.Util
{
	public interface IReportProvider
	{
		IEnumerable<SalesItem> GetReportSalesItems();
	}
}
