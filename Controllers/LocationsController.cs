using AirlineApp.Business;
using AirlineApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost]
        public IActionResult AddLocation([FromBody] LocationCreateDTO model)
        {
            var result = _locationService.AddLocation(model);
            if(!result.Status)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetLocation(Guid id) 
        { 
            var result = _locationService.GetLocation(id);
            if (!result.Status)
            {
                return NotFound(result.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            var result = _locationService.GetAllLocations();
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateLocation([FromRoute] Guid id, [FromBody]LocationUpdateDTO model)
        {
            var result = _locationService.UpdateLocation(id, model);
            if (!result.Status)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
