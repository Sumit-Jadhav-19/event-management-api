using event_mgt_server.Models.DTOs;
using event_mgt_server.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace event_mgt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventService _event;
        public EventController(IEventService eventService)
        {
            _event = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var result = await _event.GetAllEventsAsync();
            return Ok(result);
        }
        [HttpGet("GetEvent/{eventId:int}")]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var result = await _event.GetEventById(eventId);
            if (result.StatusCode == (int)Status.success)
                return Ok(result);
            else if (result.StatusCode == (int)Status.notfound)
                return NotFound(result);
            return BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] EventDTO @event)
        {
            var result = await _event.AddEventAsync(@event);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEvent(int eventId, EventDTO @event)
        {
            var result = await _event.UpdateEventAsync(eventId, @event);
            if (result.StatusCode == (int)Status.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
