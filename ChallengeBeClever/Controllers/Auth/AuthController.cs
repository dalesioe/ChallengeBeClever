
using ChallengeBeClever.Application.Interfaces;
using ChallengeBeClever.Application.UseCases.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeBeClever.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequest userData)
        {
            var result = await _authService.Login(userData.UserName, userData.Password);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Error de credenciales");

        }
    }
}