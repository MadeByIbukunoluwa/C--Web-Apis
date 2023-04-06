using System;

using Microsoft.AspNetCore.Mvc;

using Catalog.Entities;

using Catalog.Repositories;

namespace Catalog.Controllers
{
	[ApiController]
	[Route("items")]
	public class ItemsController : ControllerBase
	{
		private readonly InMemItemsRepository repository;

		public ItemsController()
		{
			repository = new InMemItemsRepository();
		}
		//Get /items
		[HttpGet]
		public IEnumerable<Item> GetItems()
		{
			var items = repository.GetItems();
			return items;
		}
		//GET /items/{id}
		[HttpGet("{id}")]
        public Item GetItem(Guid id)
        {
			var item = repository.GetItem(id);
			return item;
        }
    }
}

