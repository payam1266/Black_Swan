using Black_Swan_Application.Contracts.Identity;
using Black_Swan_Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Black_Swan.API.Controllers
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
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterationRequest request)
        {
            return Ok(await _authService.Register(request));
        }
        [HttpPost("GetUserId")]
        public async Task<ActionResult<string>> GetUserId(string name)
        {
            return Ok(await _authService.GetUserDetails(name));
        }
        [HttpPost("GetRoles")]
        public async Task<ActionResult<List<IdentityRole>>> GetRoles()
        {
            try
            {
                var roles = await _authService.GetAllRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
