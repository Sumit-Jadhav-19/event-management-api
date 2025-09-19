using event_mgt_server.Models.DTOs;
using event_mgt_server.Models.Entity;
using event_mgt_server.Services.Repositories;

namespace event_mgt_server.Services.Service
{
    public interface IEventService 
    {
        Task<APIResponseEntity> GetAllEventsAsync();
        Task<APIResponseEntity> GetEventById(int EventId);
        Task<APIResponseEntity> AddEventAsync(EventDTO eventDTO);
        Task<APIResponseEntity> UpdateEventAsync(int eventId, EventDTO @event);
    }
}
