using CornerStore.API.Models;
using CornerStore.API.Services.Interfacese;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService=authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterModel customer)
        {
            var user = await _authenticationService.SignUp(customer);
            if (user.Item2 == null)
            {
                return NotFound(user.Item1);
            }
            return Ok(user.Item2);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            var result = await _authenticationService.SignIn(loginModel.Email, loginModel.Password);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost("Add-role")]
        public async Task<IActionResult> CreateRole()
        {
            var result = await _authenticationService.CreateRoles();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
