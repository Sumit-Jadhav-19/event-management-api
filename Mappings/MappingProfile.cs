using AutoMapper;
using event_mgt_server.Models.DTOs;
using event_mgt_server.Models.Entity;

namespace event_mgt_server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity → DTO
            CreateMap<Event, EventDTO>();

            // DTO → Entity
            CreateMap<EventDTO, Event>();
        }
    }
}
