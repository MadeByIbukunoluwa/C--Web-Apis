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
		public IEnumerable<ItemDto> GetItemsAsync()
		{
			// We now convert the items we get into itemDtos
			// for this we would use LINQ
			var items = repository.GetItemsAsync().Select(item => item.AsDTO());
			return items;
		}

		//GET /items/{id}
		[HttpGet("{id}")]
		public ActionResult<ItemDto> GetItemAsync(Guid id)
		{
			var item = repository.GetItemAsync(id);

			if (item is null) return NotFound();

			return item.AsDTO();
		}

		//POST /items/
		[HttpPost]
		public ActionResult<ItemDto> CreateItemAsync(CreateItemDto itemDto)
		{
			Item item = new Item()
			{
				Id = Guid.NewGuid(),
				Name = itemDto.Name,
				Price = itemDto.Price, 
				CreatedDate = DateTimeOffset.UtcNow
			};
			return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDTO());
		}

		[HttpPut("{id}")]

		public ActionResult UpdateItemAsync(Guid id, UpdateItemDto itemDto)
		{
			var existingItem = repository.GetItemAsync(id);

			if (existingItem is null)
			{
				return NotFound();
			}
			Item updatedItem = existingItem with
			{
				Name = itemDto.Name,
				Price = itemDto.Price
			};
			repository.UpdateItemAsync(updatedItem);

			return NoContent();
		}
		//DELETE /items/
		[HttpDelete("{id}")]

		public ActionResult DeleteItemAsync(Guid id)
		{
			var existingItem = repository.GetItemAsync(id);
			 
			if (existingItem is null)
			{
				return NotFound();
			}
			repository.DeleteItemAsync(id);

			return NoContent();
		}
    }
}

