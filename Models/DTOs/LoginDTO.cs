namespace event_mgt_server.Models.DTOs
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class TokenDTO
    {
        public string RefreshToken { get; set; }
    }
}
