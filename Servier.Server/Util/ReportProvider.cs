using Servier.Server.Controllers;
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
			return _fileStorageManager.GetSalesItemsFromFile();
		}

		public IEnumerable<SalesIncreaseReportItem> GetSalesIncreaseReport(DivisionType divisionType)
		{
			var report = GetReportSalesItems().ToList();
			var items = report.GroupBy(e => divisionType == DivisionType.ByItem ? e.Product : e.Shop)
				.Select(e => new SalesIncreaseReportItem
				{
					Name = e.Key,
					CurrentValue = e.First(el => el.FinYear == 2024).ValueCount,
					PreviousValue = e.First(el => el.FinYear == 2023).ValueCount,
					Percentage = (int)((e.First(el => el.FinYear == 2024).ValueCount / e.First(el => el.FinYear == 2023).ValueCount - 1) * 100)
				});
			return items;
		}

		public IEnumerable<ReportItemIncreaseByYears> GetYearlyIncreaseReportData(string byItem, string byShop)
		{
			var report = GetReportSalesItems().ToList();
			var items = report.Where(e => (string.IsNullOrEmpty(byItem) || e.Product == byItem) && (string.IsNullOrEmpty(byShop) || e.Shop == byShop))
			.GroupBy(e => e.FinYear)
			.Select(e => new ReportItemIncreaseByYears
			{
				Year = e.Key,
				SalesSum = e.Sum(el => el.ValueCount),
				Percentage = 0
			});
			return items;
		}
	}

	public enum DivisionType
	{
		ByItem = 1,
		ByShop = 2
	}

	public class SalesIncreaseReportItem
	{
		public long PreviousValue { get; set; }
		public long CurrentValue { get; set; }
		public int Percentage { get; set; }
		public string Name { get; set; }
	}

	public class ReportItemIncreaseByYears
	{
		public int Year { get; set; }
		public long SalesSum { get; set; }
		public long Percentage { get; set; }
	}
}
