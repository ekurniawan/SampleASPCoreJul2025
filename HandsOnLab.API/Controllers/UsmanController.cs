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
