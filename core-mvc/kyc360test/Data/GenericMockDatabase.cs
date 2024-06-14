using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kyc360test.Models;

namespace kyc360test.Data
{
    public class GenericMockDatabase<T, TId> where T : IIdentifiable<TId>
    {
        private ConcurrentDictionary<TId, T> items = new ConcurrentDictionary<TId, T>();

        public bool AddItem(T item)
        {
            return items.TryAdd(item.Id, item);
        }

        public T GetItemById(TId id)
        {
            items.TryGetValue(id, out var item);
            return item;
        }

        public bool UpdateItem(TId id, T updatedItem)
        {
            if (items.TryGetValue(id, out var currentItem))
            {
                return items.TryUpdate(id, updatedItem, currentItem);
            }
            return false;
        }

        public bool DeleteItem(TId id)
        {
            return items.TryRemove(id, out var removedItem);
        }

        public IEnumerable<T> GetAllItems()
        {
            return items.Values;
        }

    }
}