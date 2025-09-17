using event_mgt_server.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace event_mgt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _event;
        public EventController(IEventService eventService)
        {
            _event = eventService;
        }

        [HttpGet]
        public  async Task<IActionResult> GetAllEvents()
        {
            var result=await _event.GetAllEventsAsync();
            return Ok(result);
        }
    }
}
