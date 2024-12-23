using Microsoft.AspNetCore.Mvc;
using Servier.Server.Util;

namespace Servier.Server.Controllers
{
	[ApiController]
	[Route("api/shopItems")]
	public class ShopItemsController : ControllerBase
	{
		private IShopItemRepository _shopItemRepository;

		public ShopItemsController(IShopItemRepository shopItemRepository)
		{
			_shopItemRepository = shopItemRepository;
		}
		[HttpGet]
		[Route("items")]
		public IEnumerable<string> GetItems()
		{
			return _shopItemRepository.GetAllItems();
		}
	}
}
