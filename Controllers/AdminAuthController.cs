using CornerStore.API.Models;
using CornerStore.API.Services.Interfacese;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CornerStore.API.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly IAdminAuthService _adminAuthService;

        public AdminAuthController(IAdminAuthService userAuthService)
        {
            _adminAuthService = userAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterModel customer)
        {
            var user = await _adminAuthService.AdminSignUp(customer);
            if (user.Item2 == null)
            {
                return NotFound(user.Item1);
            }
            return Ok(user.Item2);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            var result = await _adminAuthService.AdminSignIn(loginModel.Email, loginModel.Password);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
