using CornerStore.API.Models;
using CornerStore.API.Services.Interfacese;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;

        public UserAuthController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUser(RegisterModel customer)
        {
            var user = await _userAuthService.CreateUser(customer);
            if (user.Item2 == null)
            {
                return NotFound(user.Item1);
            }
            return Ok(user.Item2);
        }

        [HttpPost("userSignIn")]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            var result = await _userAuthService.UserSignIn(loginModel.Email, loginModel.Password);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
