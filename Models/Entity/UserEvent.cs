namespace event_mgt_server.Models.Entity
{
    public class UserEvent
    {
        public int UserEventId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}
