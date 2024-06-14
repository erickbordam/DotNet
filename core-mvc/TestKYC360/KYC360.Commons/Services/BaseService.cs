using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using KYC360.Commons.Models;
using KYC360.Commons.Mapper;

namespace KYC360.Commons.Services
{
    public abstract class BaseService<TDto, TEntity, TId>
        where TEntity : class, IIdentifiable<TId>
        where TDto : class
    {
        protected readonly ILogger<BaseService<TDto, TEntity, TId>> _logger;
        protected readonly GenericMapper<TDto, TEntity> _mapper;

        protected BaseService(ILogger<BaseService<TDto, TEntity, TId>> logger, GenericMapper<TDto, TEntity> mapper)
        {
            _logger = logger;
            _mapper = mapper;
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

        // Abstract CRUD methods to be implemented by derived services
        public abstract IEnumerable<TDto> GetAll();
        public abstract TDto GetById(TId id);
        public abstract void Add(TDto item);
        public abstract void Update(TId id, TDto item);
        public abstract void Delete(TId id);
    }
}