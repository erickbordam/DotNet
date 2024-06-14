using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kyc360test.Data;
using kyc360test.Models;

namespace kyc360test.Middleware
{
    public abstract class BaseService<T, TId> where T : IIdentifiable<TId>
    {
        protected readonly GenericMockDatabase<T, TId> _database;
        protected readonly ILogger _logger;


        protected BaseService(GenericMockDatabase<T, TId> database, ILogger logger)
        {
            _database = database;
            _logger = logger;

        }


        protected void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        protected void LogError(string message, Exception ex)
        {
            _logger.LogError(ex, message);
        }

        protected void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        protected void LogDebug(string message)
        {
            _logger.LogDebug(message);
        }

        protected void LogCritical(string message, Exception ex)
        {
            _logger.LogCritical(ex, message);
        }

        public virtual T GetById(TId id)
        {
            LogInformation($"Retrieving item of type {typeof(T).Name} with ID: {id}");
            return _database.GetItemById(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            LogInformation($"Retrieving all items of type {typeof(T).Name}.");
            return _database.GetAllItems();
        }

        public virtual bool Create(T item)
        {
            LogInformation($"Creating new item of type {typeof(T).Name} with ID: {item.Id}");
            return _database.AddItem(item);
        }

        public virtual bool Update(TId id, T updatedItem)
        {
            LogInformation($"Updating item of type {typeof(T).Name} with ID: {id}");
            return _database.UpdateItem(id, updatedItem);
        }

        public virtual bool Delete(TId id)
        {
            LogInformation($"Deleting item of type {typeof(T).Name} with ID: {id}");
            return _database.DeleteItem(id);
        }
    }
}