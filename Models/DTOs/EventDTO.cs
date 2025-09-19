using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace event_mgt_server.Models.DTOs
{
    public class EventDTO
    {
        [JsonIgnore]
        public int EventId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        [Required]
        public string Organizer { get; set; }
        [JsonIgnore]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedOn { get; set; }
        [JsonIgnore]
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int UpdatedBy { get; set; }

        //// Navigation properties
        //public ICollection<Ticket> Tickets { get; set; }
        //public ICollection<UserEvent> UserEvents { get; set; }
    }
}
