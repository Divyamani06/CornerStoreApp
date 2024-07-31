using CornerStore.API.Authenticaion;
using CornerStore.API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CornerStore.API.Models;
using AutoMapper;
using CornerStore.API.Services.Interfacese;
using CornerStore.API.Dtos.ResponseDtos;

namespace CornerStore.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<CustomerRole> _roleManager;
        private readonly JwtToken _jwtToken;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<Customer> userManager,
            RoleManager<CustomerRole> roleManager, IOptions<JwtToken> options,IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtToken = options.Value;
            _mapper = mapper;
        }

        public async Task<(string, CustomerResponseDto)> SignUp(RegisterModel model)
        {
            var user = _mapper.Map<Customer>(model);
            //check this user exit in db
            var userExists = await _userManager.FindByEmailAsync(user.Email);
            if (userExists != null)
            {
                return (ErrorMessage.UserAlreadyRegistered, null);
            }

            // create user into the db
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if (!result.Succeeded)
            {
                return (ErrorMessage.UserCreationFailed, null);
            }
           
            var role = await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            if (!role.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return (ErrorMessage.UserRoleAssignmentFailed, null);
            }
            var userrole = await _userManager.AddToRoleAsync(user, UserRoles.User);
            if (!userrole.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return (ErrorMessage.UserRoleAssignmentFailed, null);
            }
            
            var response = _mapper.Map<CustomerResponseDto>(user);
            return (ErrorMessage.UserCreatedSuccessfully, response);

        }

        public async Task<string> SignIn(string email, string password)
        {
            // check this user exist in db            
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return ErrorMessage.UserNotFound;
            }
            // check password was exit in db
            var checkPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!checkPassword)
            {
                return ErrorMessage.PasswordMismatch;
            }
            var roles = await _userManager.GetRolesAsync(user);
            //JWT Creation
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_jwtToken.Key);
            var claims = new ClaimsIdentity(new []
               {
               new Claim(ClaimTypes.Name ,user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
               });
            foreach (var userRole in roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, userRole));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials
                                   (new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            var tokens = tokenHandler.CreateToken(tokenDescriptor);
            var fianleToken = tokenHandler.WriteToken(tokens);
            return fianleToken;
        }

        public async Task<string> CreateRoles()
        {
            bool isAdmin = await _roleManager.RoleExistsAsync(UserRoles.Admin);
            bool isUser = await _roleManager.RoleExistsAsync(UserRoles.User);
            if(isAdmin && isUser)
            {
                return "Admin and User role already exits";
            }
            await _roleManager.CreateAsync(new CustomerRole{ Name=UserRoles.Admin});
            await _roleManager.CreateAsync(new CustomerRole { Name=UserRoles.User});

            return "Admin and User Role created Successfully";

        }
    }

}
