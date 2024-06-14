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