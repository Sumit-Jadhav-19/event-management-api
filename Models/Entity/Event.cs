using System.Net.Sockets;

namespace event_mgt_server.Models.Entity
{
    public class Event
    {
        public int EventId { get; set; }            
        public string Name { get; set; }            
        public string Description { get; set; }     
        public DateTime StartDate { get; set; }     
        public DateTime EndDate { get; set; }       
        public string Location { get; set; }        
        public int Capacity { get; set; }           
        public decimal TicketPrice { get; set; }    
        public string Organizer { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        // Navigation properties
        public ICollection<Ticket> Tickets { get; set; }  
        public ICollection<UserEvent> UserEvents { get; set; } 
    }
}
