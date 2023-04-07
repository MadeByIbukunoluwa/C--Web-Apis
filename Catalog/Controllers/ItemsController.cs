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

		//POST /items/
		[HttpPost]
		public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
		{
			Item item = new Item()
			{
				Id = Guid.NewGuid(),
				Name = itemDto.Name,
				Price = itemDto.Price,
				CreatedDate = DateTimeOffset.UtcNow
			};
			return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDTO());
		}

		[HttpPut("{id}")]

		public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
		{
			var existingItem = repository.GetItem(id);

			if (existingItem is null)
			{
				return NotFound();
			}
			Item updatedItem = existingItem with
			{
				Name = itemDto.Name,
				Price = itemDto.Price
			};
			repository.UpdateItem(updatedItem);

			return NoContent();
		}
		//DELETE /items/
		[HttpDelete("{id}")]

		public ActionResult DeleteItem(Guid id)
		{
			var existingItem = repository.GetItem(id);
			 
			if (existingItem is null)
			{
				return NotFound();
			}
			repository.DeleteItem(id);

			return NoContent();
		}
    }
}

