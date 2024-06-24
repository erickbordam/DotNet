using System;
using System.Collections.Generic;
using System.Linq;
using KYC360.Commons.DTOs;
using KYC360.Commons.Mapper;
using KYC360.Commons.Models;
using KYC360.Commons.Services;
using KYC360.Core.Data;
using KYC360.Core.Models;
using Microsoft.Extensions.Logging;

namespace KYC360.Core.Services
{
    public class EntityService : BaseService<EntityDTO, Entity, string>
    {
        private readonly GenericMockDatabase<Entity, string> _database;
        private readonly Dictionary<int, string> _addressLineDescriptions;
        private readonly Dictionary<int, string> _cityNames;
        private readonly Dictionary<int, string> _countryNames;

        public EntityService(GenericMockDatabase<Entity, string> database, GenericMapper<EntityDTO, Entity> mapper, ILogger<EntityService> logger)
            : base(logger, mapper)
        {
            _database = database;

            // Initialize the lookup dictionaries
            _addressLineDescriptions = new Dictionary<int, string>
            {
                { 1, "1234 Elm Street" },
                { 2, "5678 Oak Avenue" },
                { 3, "9101 Pine Lane" },
                { 4, "1415 Maple Street" },
                { 5, "1617 Birch Road" },
                { 6, "1819 Cedar Blvd" }
            };

            _cityNames = new Dictionary<int, string>
            {
                { 1, "Metropolis" },
                { 2, "Gotham" },
                { 3, "Star City" },
                { 4, "Central City" },
                { 5, "Coast City" },
                { 6, "Bludhaven" }
            };

            _countryNames = new Dictionary<int, string>
            {
                { 1, "Freedonia" },
                { 2, "Genovia" },
                { 3, "Elbonia" },
                { 4, "Zamunda" },
                { 5, "Wakanda" },
                { 6, "Latveria" }
            };
        }

        public override IEnumerable<EntityDTO> GetAll()
        {
            LogInformation("Retrieving all entities.");
            var entities = _database.GetAllItems();
            var entitiesDTO = _mapper.MapToDto(entities);
            foreach (var entityDTO in entitiesDTO)
            {
                PopulateAddressDescriptions(entityDTO);
            }
            return entitiesDTO;
        }

        public override EntityDTO? GetById(string id)
        {
            LogInformation($"Retrieving entity with ID: {id}");
            var entity = _database.GetItemById(id);
            if (entity != null)
            {
                var entityDTO = _mapper.MapToDto(entity);
                PopulateAddressDescriptions(entityDTO);
                return entityDTO;
            }
            return null;
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

        public IEnumerable<EntityDTO> Search(string searchTerm)
        {
            LogInformation($"Searching entities with term: {searchTerm}");

            if (string.IsNullOrEmpty(searchTerm))
            {
                return Enumerable.Empty<EntityDTO>();
            }

            var entityDTOs = GetAll()
                .Where(e =>
                    (e.Addresses != null && e.Addresses.Any(a => 
                        (a.CountryName?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (a.AddressLineDesc?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false))) ||
                    (e.Names != null && e.Names.Any(n => 
                        (n.FirstName?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (n.MiddleName?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (n.Surname?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false))))
                .ToList();
            return entityDTOs;
        }

        public IEnumerable<EntityDTO> Filter(string? gender, DateTime? startDate, DateTime? endDate, List<string> countries)
        {
            LogInformation("Filtering entities.");

            var entityDTOs = GetAll()
                .Where(e =>
                    (string.IsNullOrEmpty(gender) || e.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)) &&
                    (!startDate.HasValue || (e.Dates != null && e.Dates.Any(d => d.DateVal >= startDate))) &&
                    (!endDate.HasValue || (e.Dates != null && e.Dates.Any(d => d.DateVal <= endDate))) &&
                    (!countries.Any() || (e.Addresses != null && e.Addresses.Any(a => countries.Contains(a.CountryName))))
                )
                .ToList();
            return entityDTOs;
        }

        private void PopulateAddressDescriptions(EntityDTO entity)
        {
            foreach (var address in entity.Addresses)
            {
                address.AddressLineDesc = GetAddressLineDescription(address.AddressLine);
                address.CityName = GetCityName(address.City);
                address.CountryName = GetCountryName(address.Country);
            }
        }

        private string? GetAddressLineDescription(int? addressLineId)
        {
            // Lookup the address line description
            return addressLineId.HasValue && _addressLineDescriptions.TryGetValue(addressLineId.Value, out var description) ? description : null;
        }

        private string? GetCityName(int? cityId)
        {
            // Lookup the city name
            return cityId.HasValue && _cityNames.TryGetValue(cityId.Value, out var name) ? name : null;
        }

        private string? GetCountryName(int? countryId)
        {
            // Lookup the country name
            return countryId.HasValue && _countryNames.TryGetValue(countryId.Value, out var name) ? name : null;
        }

        public IEnumerable<EntityDTO> PaginateAndSort(IEnumerable<EntityDTO> entities, int pageNumber, int pageSize, string sortBy, bool sortDesc)
        {
            LogInformation("Applying pagination and sorting.");

            // Sorting
            entities = sortBy switch
            {
                "id" => sortDesc ? entities.OrderByDescending(e => e.Id) : entities.OrderBy(e => e.Id),
                "gender" => sortDesc ? entities.OrderByDescending(e => e.Gender) : entities.OrderBy(e => e.Gender),
                "deceased" => sortDesc ? entities.OrderByDescending(e => e.Deceased) : entities.OrderBy(e => e.Deceased),
                "address" => sortDesc ? entities.OrderByDescending(e => e.Addresses.FirstOrDefault()?.AddressLineDesc) : entities.OrderBy(e => e.Addresses.FirstOrDefault()?.AddressLineDesc),
                _ => entities
            };

            // Pagination
            entities = entities.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return entities;
        }
    }
}
