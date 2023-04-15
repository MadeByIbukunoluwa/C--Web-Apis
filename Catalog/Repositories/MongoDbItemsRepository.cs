using System;

using Catalog.Entities;

using MongoDB.Driver;

using MongoDB.Bson;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IInMemItemsRepository
    {

        private const string databaseName = "catalog";

        private const string collectionName = "items";

        private readonly IMongoCollection<Item> itemsCollection;

        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        public async Task CreateItemAsync(Item item)
        {
           await itemsCollection.InsertOneAsync(item);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            await itemsCollection.DeleteOneAsync(filter);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync() 
        {
            // Gives us the list of items in the collection 
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();
        }
         
        public async Task UpdateItemAsync(Item item)
        {
            // we need to use a filter here too, to tell which item to update
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            // we aren't returning anything here
            await itemsCollection.ReplaceOneAsync(filter, item);
        }
    }


}

