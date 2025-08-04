using HandsOnLab.BL;
using HandsOnLab.BL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnLab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsmanController : ControllerBase
    {
        private readonly IUsmanBL _usmanBL;

        public UsmanController(IUsmanBL usmanBL)
        {
            _usmanBL = usmanBL;
        }

        //login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest("Login data cannot be null");
            }
            try
            {
                var userWithToken = await _usmanBL.LoginAsync(loginDTO);
                if (userWithToken != null)
                {
                    return Ok(userWithToken);
                }
                else
                {
                    return Unauthorized("Invalid login credentials");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        //registration
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegistrationDTO registrationDTO)
        {
            if (registrationDTO == null)
            {
                return BadRequest("Registration data cannot be null");
            }
            try
            {
                var result = await _usmanBL.RegisterAsync(registrationDTO);
                if (result)
                {
                    return Ok("Registration successful");
                }
                else
                {
                    return BadRequest("Registration failed");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
