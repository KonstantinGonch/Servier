namespace Servier.Server.Util
{
	public interface IShopRepository
	{
		public IEnumerable<string> GetAllItems();
	}
}
