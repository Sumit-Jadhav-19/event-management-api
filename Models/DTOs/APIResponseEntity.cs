namespace event_mgt_server.Models.DTOs
{
    public class APIResponseEntity
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
    public enum Status
    {
        error,
        success,
        pending,
        notfound
    }
}
