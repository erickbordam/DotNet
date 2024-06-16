using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Commons.Models;

namespace KYC360.Core.Data
{
    public class GenericMockDatabase<T, TId> where T : IIdentifiable<TId>
    {
        private readonly ConcurrentDictionary<TId, T> items = new ConcurrentDictionary<TId, T>();
        private readonly ILogger<GenericMockDatabase<T, TId>> _logger;
        private readonly int _maxRetryAttempts;
        private readonly int _initialDelay;
        private readonly int _maxDelay;
        private readonly double _backoffFactor;

        public GenericMockDatabase(ILogger<GenericMockDatabase<T, TId>> logger, int maxRetryAttempts = 3, 
                                   int initialDelay = 1000, int maxDelay = 8000, double backoffFactor = 2.0)
        {
            _logger = logger;
            _maxRetryAttempts = maxRetryAttempts;
            _initialDelay = initialDelay;
            _maxDelay = maxDelay;
            _backoffFactor = backoffFactor;
        }

        public bool AddItem(T item)
        {
            return RetryPolicy(() => items.TryAdd(item.Id, item), nameof(AddItem));
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
                return RetryPolicy(() => items.TryUpdate(id, updatedItem, currentItem), nameof(UpdateItem));
            }
            return false;
        }

        public bool DeleteItem(TId id)
        {
            return RetryPolicy(() => items.TryRemove(id, out _), nameof(DeleteItem));
        }

        public IEnumerable<T> GetAllItems()
        {
            return items.Values;
        }

        private bool RetryPolicy(Func<bool> operation, string operationName)
        {
            int attempt = 0;
            int delay = _initialDelay;

            while (attempt < _maxRetryAttempts)
            {
                attempt++;
                try
                {
                    if (operation())
                    {
                        _logger.LogInformation($"{operationName} succeeded on attempt {attempt}");
                        return true;
                    }
                    else
                    {
                        _logger.LogWarning($"{operationName} failed on attempt {attempt}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning($"{operationName} threw an exception on attempt {attempt}: {ex.Message}");
                }

                _logger.LogInformation($"{operationName} retrying in {delay}ms...");
                Thread.Sleep(delay);
                delay = Math.Min((int)(delay * _backoffFactor), _maxDelay);
            }

            _logger.LogError($"{operationName} failed after {_maxRetryAttempts} attempts");
            return false;
        }
    }
}