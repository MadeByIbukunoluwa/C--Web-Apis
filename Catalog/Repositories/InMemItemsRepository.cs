using System.Collections.Generic;

using  Catalog.Entities;

using System.Linq;

//we don't really need the repositories class again but for learning purposes ,we will convert all the methods
// into async methods
namespace Catalog.Repositories
{
    public class InMemItemsRepository : IInMemItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "potion",Price = 9,CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "potion",Price = 9,CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "potion",Price = 9,CreatedDate = DateTimeOffset.UtcNow}
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            // we will await it nomrally, but since we don't have any asynchrnous method
            //to call , we will use Task.fromResult - this means we want to create a task that already completed
            // and we want to intriduc the value of the items into that Task
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {

            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }
        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }
        public async Task UpdateItemAsync(Item item)
        {
            // we find theindex of the item we are looking for , then update it 
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            // then we update the item we reassigning the item at that index 
            items[index] = item;
            await Task.CompletedTask;
        }
        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}

