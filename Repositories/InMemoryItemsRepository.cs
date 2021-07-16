using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;


namespace Catalog.Repositories
{

    public class InMemoryItemsRepository : IInMemoryItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion 1", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Potion 2", Price = 10, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Potion 3", Price = 11, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(a => a.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }
        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(a => a.Id == item.Id);
            items[index] = item;
        }

         public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(a => a.Id ==id);
            items.RemoveAt(index);
        }
    }

}