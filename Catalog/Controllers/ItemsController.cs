using System;

using Microsoft.AspNetCore.Mvc;

using Catalog.Entities;

using Catalog.Repositories;

using Catalog.Dtos;

namespace Catalog.Controllers
{
	[ApiController]
	[Route("items")]
	public class ItemsController : ControllerBase
	{
		private readonly IInMemItemsRepository repository;

		public ItemsController(IInMemItemsRepository repository)
		{
			
			//repository = new InMemItemsRepository();
			this.repository = repository;
		}

		//Get /items
		[HttpGet]
		public IEnumerable<ItemDto> GetItems()
		{
			// We now convert the items we get into itemDtos
			// for this we would use LINQ
			var items = repository.GetItems().Select(item => item.AsDTO());
			return items;
		}

		//GET /items/{id}
		[HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
			var item = repository.GetItem(id);

			if (item is null) return NotFound();

			return item.AsDTO();
        }
    }
}

