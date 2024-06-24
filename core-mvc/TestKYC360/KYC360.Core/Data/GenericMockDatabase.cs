using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using KYC360.Commons.Models;
using Microsoft.Extensions.Logging;

namespace KYC360.Core.Data
{
    public class GenericMockDatabase<T, TId> where T : IIdentifiable<TId> where TId : notnull
    {
        private readonly ConcurrentDictionary<TId, T> _items;
        private readonly ILogger<GenericMockDatabase<T, TId>> _logger;
        private readonly int _maxRetryAttempts;
        private readonly int _initialDelay;
        private readonly int _maxDelay;
        private readonly double _backoffFactor;

        public GenericMockDatabase(
            ILogger<GenericMockDatabase<T, TId>> logger, 
            int maxRetryAttempts, 
            int initialDelay, 
            int maxDelay, 
            double backoffFactor,
            ConcurrentDictionary<TId, T>? items = null)  // allow injecting dictionary for testing
        {
            _items = items ?? new ConcurrentDictionary<TId, T>();
            _logger = logger;
            _maxRetryAttempts = maxRetryAttempts;
            _initialDelay = initialDelay;
            _maxDelay = maxDelay;
            _backoffFactor = backoffFactor;
        }

        public bool AddItem(T item)
        {
            return RetryPolicy(() => _items.TryAdd(item.Id, item), nameof(AddItem));
        }

        public T? GetItemById(TId id)
        {
            _items.TryGetValue(id, out var item);
            return item;
        }

        public bool UpdateItem(TId id, T updatedItem)
        {
            if (_items.TryGetValue(id, out var currentItem))
            {
                return RetryPolicy(() => _items.TryUpdate(id, updatedItem, currentItem), nameof(UpdateItem));
            }
            return false;
        }

        public bool DeleteItem(TId id)
        {
            return RetryPolicy(() => _items.TryRemove(id, out _), nameof(DeleteItem));
        }

        public IEnumerable<T> GetAllItems()
        {
            return _items.Values;
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
