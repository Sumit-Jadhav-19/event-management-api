using event_mgt_server.Models.DTOs;
using event_mgt_server.Models.Entity;

namespace event_mgt_server.Services.Service
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<object> LoginAsync(LoginDTO model);
        Task<object> RefreshTokenAsync(TokenDTO tokenModel);
    }
}
