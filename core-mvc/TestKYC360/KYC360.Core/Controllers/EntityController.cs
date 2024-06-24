using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Commons.DTOs;
using KYC360.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace KYC360.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly EntityService _entityService;

        public EntityController(EntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EntityDTO>> Get()
        {
            var entities = _entityService.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public ActionResult<EntityDTO> Get(string id)
        {
            var entity = _entityService.GetById(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<EntityDTO>> GetSearch([FromQuery] string? search, [FromQuery] string? gender, 
                                                              [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, 
                                                              [FromQuery] List<string>? countries, 
                                                              [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, 
                                                              [FromQuery] string sortBy = "id", [FromQuery] bool sortDesc = false)
        {
            IEnumerable<EntityDTO> results;

            if (!string.IsNullOrEmpty(search))
            {
                results = _entityService.Search(search);
            }
            else
            {
                results = _entityService.Filter(gender, startDate, endDate, countries ?? new List<string>());
            }

            var pagedAndSortedResults = _entityService.PaginateAndSort(results, pageNumber, pageSize, sortBy, sortDesc);
            return Ok(pagedAndSortedResults);
        }

        [HttpPost]
        public ActionResult Create([FromBody] EntityDTO entityDto)
        {
            _entityService.Add(entityDto);
            return CreatedAtAction(nameof(Get), new { id = entityDto.Id }, entityDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] EntityDTO entityDto)
        {
            _entityService.Update(id, entityDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _entityService.Delete(id);
            return NoContent();
        }
    }
}
