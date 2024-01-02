using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalsk.Api.Models.Domain;

namespace NZWalsk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id= Guid.NewGuid(),
                    Name= "Nairobi",
                    Code="NBI",
                    RegionImageUrl="https://images.unsplash.com/photo-1611144727915-ef30a08aaeb3?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bmFpcm9iaSUyMGNpdHl8ZW58MHx8MHx8fDA%3D"
                },
                new Region
                {
                    Id= Guid.NewGuid(),
                    Name= "Mombasa",
                    Code="MBSA",
                    RegionImageUrl="https://images.unsplash.com/photo-1611144727915-ef30a08aaeb3?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bmFpcm9iaSUyMGNpdHl8ZW58MHx8MHx8fDA%3D"
                }
            };
            return Ok(regions);
        }
    }
}
