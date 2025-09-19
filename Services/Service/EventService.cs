using AutoMapper;
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
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EventService(AppDbContext context, ILogger<EventService> logger, IRepository<Event> repository, AppDbContext appDbContext, IMapper mapper)
        {
            _logger = logger;
            _eventRepository = repository;
            _context = appDbContext;
            _mapper = mapper;
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
        public async Task<APIResponseEntity> AddEventAsync(EventDTO eventDTO)
        {
            APIResponseEntity _response = new();
            try
            {
                Event e = _mapper.Map<Event>(eventDTO);
                await _eventRepository.AddAsync(e);
                await _eventRepository.SaveAsync();
                _response.StatusCode = 1;
                _response.Status = "Status";
                _response.Message = "Event saved successfully !";
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
        public async Task<APIResponseEntity> UpdateEventAsync(int eventId, EventDTO @event)
        {
            APIResponseEntity _response = new();
            try
            {
                var existingEvent = await _eventRepository.GetByIdAsync(eventId);

                if (existingEvent == null)
                {
                    _response.StatusCode = (int)Status.notfound;
                    _response.Message = $"Event with ID {eventId} not found.";
                    return _response;
                }

                // ✅ AutoMapper approach
                _mapper.Map(@event, existingEvent); // maps DTO onto existing entity

                _eventRepository.Update(existingEvent);
                await _eventRepository.SaveAsync();
                _response.StatusCode = (int)Status.success;
                _response.Message = "Event updated successfully.";
                _response.Data = existingEvent; // or map back to DTO if needed
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return _response;
        }
    }
}
