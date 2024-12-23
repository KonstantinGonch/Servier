namespace Servier.Server.Util
{
	public class ShopRepository : IShopRepository
	{
		private IReportProvider _reportProvider;

		public ShopRepository(IReportProvider reportProvider)
		{
			_reportProvider = reportProvider;
		}
		public IEnumerable<string> GetAllItems()
		{
			var report = _reportProvider.GetReportSalesItems();
			return report.Select(e => e.Shop).Distinct();
		}
	}
}
