using CNLTHD.DTO;
using CNLTHD.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CNLTHD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _authService.Register(createUserDto);
            if (user == null) 
                return BadRequest(new
                {
                    success = false,
                    message = "Email or Phone already exists!"
                });
            return Ok(new { success = true, message = "Register successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _authService.Login(loginUserDto);
            if (string.IsNullOrEmpty(token)) 
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid Username or Passowrd"
                });
            return Ok(new
            {
                success = true,
                message = "Authentication success",
                token
            });
        }
    }
}
