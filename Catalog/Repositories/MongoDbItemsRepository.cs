using System;
using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IInMemItemsRepository
    {

        private const string databaseName = "catalog";

        private const string collectionName = "items";

        private readonly IMongoCollection<Item> itemsCollection;


        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        void IInMemItemsRepository.CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        void IInMemItemsRepository.DeleteItem(Guid id)
        {
            throw new NotImplementedException();

        }

        Item IInMemItemsRepository.GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Item> IInMemItemsRepository.GetItems()
        {
            throw new NotImplementedException();
        }

        void IInMemItemsRepository.UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}

