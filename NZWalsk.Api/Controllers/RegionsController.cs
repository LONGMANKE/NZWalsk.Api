using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalsk.Api.Data;
using NZWalsk.Api.Models.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalsk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;
        private readonly ILogger<RegionsController> _logger;

        public RegionsController(NZWalksDbContext dbContext, ILogger<RegionsController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var regions = _dbContext.Regions.ToList();
                return Ok(regions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching regions from the database.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var region = _dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if (region == null)
                return NotFound();
            return Ok(region);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Region region)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, region);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id, [FromBody] Region updatedRegion)
        {
            var region = await _dbContext.Regions.FindAsync(id);
            if (region == null)
                return NotFound();

            region.Name = updatedRegion.Name;
            region.Code = updatedRegion.Code;
            region.RegionImageUrl = updatedRegion.RegionImageUrl;

            await _dbContext.SaveChangesAsync();
            return Ok(region);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var region = await _dbContext.Regions.FindAsync(id);
            if (region == null)
                return NotFound();

            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();

            return Ok(region);
        }
    }
}
