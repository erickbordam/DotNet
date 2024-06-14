using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Commons.DTOs;
using KYC360.Commons.Mapper;
using KYC360.Commons.Models;
using KYC360.Commons.Services;
using KYC360.Core.Data;
using KYC360.Core.Models;

namespace KYC360.Core.Services
{
    public class EntityService : BaseService<EntityDTO, Entity, string>
    {
        private readonly GenericMockDatabase<Entity, string> _database;

        public EntityService(GenericMockDatabase<Entity, string> database, GenericMapper<EntityDTO, Entity> mapper, ILogger<EntityService> logger)
            : base(logger, mapper)
        {
            _database = database;
        }

        public override IEnumerable<EntityDTO> GetAll()
        {
            LogInformation("Retrieving all entities.");
            var entities = _database.GetAllItems();
            return _mapper.MapToDto(entities);
        }

        public override EntityDTO GetById(string id)
        {
            LogInformation($"Retrieving entity with ID: {id}");
            var entity = _database.GetItemById(id);
            return entity != null ? _mapper.MapToDto(entity) : null;
        }

        public override void Add(EntityDTO entityDto)
        {
            LogInformation($"Adding new entity with ID: {entityDto.Id}");
            var entity = _mapper.MapToEntity(entityDto);
            _database.AddItem(entity);
        }

        public override void Update(string id, EntityDTO entityDto)
        {
            LogInformation($"Updating entity with ID: {id}");
            var entity = _mapper.MapToEntity(entityDto);
            entity.Id = id;
            _database.UpdateItem(id, entity);
        }

        public override void Delete(string id)
        {
            LogInformation($"Deleting entity with ID: {id}");
            _database.DeleteItem(id);
        }
    }
}