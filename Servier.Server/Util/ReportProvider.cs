using Servier.Server.Models;

namespace Servier.Server.Util
{
	public class ReportProvider : IReportProvider
	{
		private IReportFileStorageManager _fileStorageManager;
		public ReportProvider(IReportFileStorageManager reportFileStorageManager) 
		{ 
			_fileStorageManager = reportFileStorageManager;
		}

		public IEnumerable<SalesItem> GetReportSalesItems()
		{
			throw new NotImplementedException();
		}
	}
}
