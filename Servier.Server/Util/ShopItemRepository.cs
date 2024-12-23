
namespace Servier.Server.Util
{
	public class ShopItemRepository : IShopItemRepository
	{
		private IReportProvider _reportProvider;

		public ShopItemRepository(IReportProvider reportProvider)
		{
			_reportProvider = reportProvider;
		}
		public IEnumerable<string> GetAllItems()
		{
			var report = _reportProvider.GetReportSalesItems();
			return report.Select(e => e.Product).Distinct();
		}
	}
}
