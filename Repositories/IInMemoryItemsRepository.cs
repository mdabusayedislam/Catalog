using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;
namespace Catalog.Repositories
{
    public interface IInMemoryItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}