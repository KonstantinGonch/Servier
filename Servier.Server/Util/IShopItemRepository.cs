namespace Servier.Server.Util
{
	public interface IShopItemRepository
	{
		public IEnumerable<string> GetAllItems();
	}
}
