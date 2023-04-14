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
        public void CreateItemAsync(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();

        }

        public Item GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItemsAsync()
        {
            // Gives us the list of items in the collection 
            return itemsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItemAsync(Item item)
        {
            // we need to use a filter here too, to tell which item to update
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemsCollection.ReplaceOne(filter, item);
        }
    }
}

