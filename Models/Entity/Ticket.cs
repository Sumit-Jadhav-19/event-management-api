namespace event_mgt_server.Models.Entity
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }
    }
}
