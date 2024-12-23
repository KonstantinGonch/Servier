using Servier.Server.Models;

namespace Servier.Server.Util
{
	public interface IReportFileStorageManager
	{
		IEnumerable<SalesItem> GetSalesItemsFromFile();
	}
}
