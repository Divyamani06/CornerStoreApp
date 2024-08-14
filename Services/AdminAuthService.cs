using AutoMapper;
using CornerStore.API.Authenticaion;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Models;
using CornerStore.API.Repositories.Interfacese;
using CornerStore.API.Services.Interfacese;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CornerStore.API.Services
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly JwtToken _jwtToken;
        private readonly IMapper _mapper;

        public AdminAuthService(IAuthenticationRepository authenticationRepository, IOptions<JwtToken> options, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _jwtToken = options.Value;
            _mapper = mapper;
        }

        public async Task<(string, CustomerResponseDto)> AdminSignUp(RegisterModel model)
        {
            var user = _mapper.Map<Customer>(model);
            //check this user exit in db
            var userExists = await _authenticationRepository.FindByEmailAsync(user.Email);
            if (userExists != null)
            {
                return (ErrorMessage.UserAlreadyRegistered, null);
            }

            // create user into the db
            var result = await _authenticationRepository.CreateAsync(user, user.PasswordHash);
            if (!result.Succeeded)
            {
                return (ErrorMessage.UserCreationFailed, null);
            }
            bool isAdmin = await _authenticationRepository.RoleExistsAsync(UserRoles.Admin);
            if (!isAdmin)
            {
                await _authenticationRepository.CreateAsync(new CustomerRole { Name = UserRoles.Admin });
            }
            var role = await _authenticationRepository.AddToRoleAsync(user, UserRoles.Admin);
            if (!role.Succeeded)
            {
                await _authenticationRepository.DeleteAsync(user);
                return (ErrorMessage.UserRoleAssignmentFailed, null);
            }
            var response = _mapper.Map<CustomerResponseDto>(user);
            return (ErrorMessage.UserCreatedSuccessfully, response);

        }

        public async Task<string> AdminSignIn(string email, string password)
        {
            // check this user exist in db            
            var user = await _authenticationRepository.FindByEmailAsync(email);
            if (user == null)
            {
                return ErrorMessage.UserNotFound;
            }
            // check password was exit in db
            var checkPassword = await _authenticationRepository.CheckPasswordAsync(user, password);
            if (!checkPassword)
            {
                return ErrorMessage.PasswordMismatch;
            }
            var roles = await _authenticationRepository.GetRolesAsync(user);
            //JWT Creation
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_jwtToken.Key);
            var claims = new ClaimsIdentity(new[]
               {
               new Claim(ClaimTypes.Email ,user.Email),
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
    }
}
