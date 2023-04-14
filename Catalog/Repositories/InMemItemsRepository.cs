using System.Collections.Generic;

using  Catalog.Entities;

using System.Linq;

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

        public IEnumerable<Item> GetItemsAsync()
        {
            return items;
        }
        public Item GetItemAsync(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
        public void CreateItemAsync(Item item)
        {
            items.Add(item);
        }
        public void UpdateItemAsync(Item item)
        {
            // we find theindex of the item we are looking for , then update it 
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            // then we update the item we reassigning the item at that index 
            items[index] = item;
        }
        public void DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}

