using Catalog.Entities;


namespace Catalog.Repositories
{
    public interface IInMemItemsRepository
    {
        Task GetItemAsync(Guid id);

        IEnumerable<Task> GetItems();

        async CreateItem(Item item);

        async UpdateItem(Item item);

        async DeleteItem(Guid id);
    }
}