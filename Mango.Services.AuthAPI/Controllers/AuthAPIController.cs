using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController(IAuthService authService) : ControllerBase
    {
        private readonly ResponseDto response = new();

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationRequestDTO model)
        {
            var errorMessage = await authService.Register(model);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                response.IsSuccess = false;
                response.Message = errorMessage;
                return BadRequest(response);
            }
            return Ok(response);
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await authService.Login(model);
            if (loginResponse.User == null)
            {
                response.IsSuccess = false;
                response.Message = "Username of password is incorrect";
                return BadRequest(response);
            }
            response.Result = loginResponse;
            return Ok(response);

        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO model)
        {
            var assignRole = await authService.AssignRole(model.Email, model.Role.ToUpper());
            if(assignRole)
            {
                response.IsSuccess = false;
                response.Message = "Error Encountered";
                return BadRequest(response);
            }
            response.Result = assignRole;
            return Ok(response);

        }
    }
}
