using Microsoft.AspNetCore.Mvc;
using Servier.Server.Util;

namespace Servier.Server.Controllers
{
	[ApiController]
	[Route("api/shops")]
	public class ShopsController : ControllerBase
	{
		private IShopRepository _shopRepository;

		public ShopsController(IShopRepository shopItemRepository)
		{
			_shopRepository = shopItemRepository;
		}
		[HttpGet]
		[Route("items")]
		public IEnumerable<string> GetItems()
		{
			return _shopRepository.GetAllItems();
		}
	}
}
