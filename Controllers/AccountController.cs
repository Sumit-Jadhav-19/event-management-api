using event_mgt_server.Models.DTOs;
using event_mgt_server.Models.Entity;
using event_mgt_server.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace event_mgt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model);
            if (result == "Registration successful.")
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var result = await _authService.LoginAsync(model);
            if (result == "Invalid credentials")
                return Unauthorized(result);
            return Ok(result);
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> Refresh(TokenDTO tokenModel)
        {
            var result = await _authService.RefreshTokenAsync(tokenModel);
            return Ok(result);
        }
    }
}
