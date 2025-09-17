using event_mgt_server.Data;
using event_mgt_server.Models.DTOs;
using event_mgt_server.Models.Entity;
using event_mgt_server.Services.Repositories;

namespace event_mgt_server.Services.Service
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly ILogger<EventService> _logger;
        public EventService(AppDbContext context, ILogger<EventService> logger, IRepository<Event> repository)
        {
            _logger = logger;
            _eventRepository = repository;
        }

        public async Task<APIResponseEntity> GetAllEventsAsync()
        {
            APIResponseEntity _response = new();
            try
            {
                var result = await _eventRepository.GetAllAsync();
                _response.StatusCode = 1;
                _response.Status = "Success";
                _response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.StatusCode = 0;
                _response.Status = "Something went wrong";
            }
            return _response;
        }
        public async Task<APIResponseEntity> GetEventById(int EventId)
        {
            APIResponseEntity _response = new();
            try
            {
                var result = await _eventRepository.GetByIdAsync(EventId);
                if (result != null)
                {
                    _response.StatusCode = 1;
                    _response.Status = "Status";
                    _response.Data = result;
                }
                else
                {
                    _response.StatusCode = (int)Status.notfound;
                    _response.Status = Status.notfound.ToString();
                    _response.Message = "Event not found !";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.StatusCode = 0;
                _response.Status = Status.error.ToString();
                _response.Status = "Something went wrong";
            }
            return _response;
        }
    }
}
