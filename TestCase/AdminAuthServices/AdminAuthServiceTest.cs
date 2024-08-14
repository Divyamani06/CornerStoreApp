using AutoMapper;
using CornerStore.API.Authenticaion;
using CornerStore.API.Dtos.ResponseDtos;
using CornerStore.API.Model;
using CornerStore.API.Models;
using CornerStore.API.Repositories.Interfacese;
using CornerStore.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace CornerStore_Tests.Services.AdminAuthServices
{
    public class AdminAuthServiceTest
    {
        private readonly IAuthenticationRepository _athenticationRepository;
        private readonly IOptions<JwtToken> _jwtToken;
        private readonly IMapper _mapper;
        private readonly AdminAuthService _sut;
        public AdminAuthServiceTest()
        {
            _athenticationRepository = Substitute.For<IAuthenticationRepository>();
            _mapper = Substitute.For<IMapper>();
            _jwtToken = Substitute.For<IOptions<JwtToken>>();
            _sut = new AdminAuthService(_athenticationRepository, _jwtToken, _mapper);
        }

        [Fact]
        public async Task AdminSignUp_WhenCustomerPassedVaild_ReturnSuccess()
        {
            var result = new RegisterModel
            {
                FirstName = "test",
                LastName = "test",
                Email = "test@example.com",
                Address = "testing",
                PhoneNumber = "89790988",
            };
            Customer user = new()
            {
                FirstName = "test",
                LastName = "test",
                Email = "test@example.com",
                Address = "testing",
                PhoneNumber = "89790988",
            };
            var customerResponseDto = new CustomerResponseDto
            {
                FirstName = "test",
                LastName = "test",
                Email = "test@example.com",
                Address = "testing",
                PhoneNumber = "89790988",

            };
            _mapper.Map<Customer>(Arg.Any<RegisterModel>()).Returns(user);
            _athenticationRepository.FindByEmailAsync(Arg.Any<string>()).Returns(Task.FromResult<Customer>(null));
            _athenticationRepository.CreateAsync(Arg.Any<Customer>(), Arg.Any<string>()).Returns(IdentityResult.Success, IdentityResult.Success);
            _athenticationRepository.RoleExistsAsync(Arg.Any<string>()).Returns(true);
            _athenticationRepository.AddToRoleAsync(Arg.Any<Customer>(), Arg.Any<string>()).Returns(IdentityResult.Success, IdentityResult.Success);
            _mapper.Map<CustomerResponseDto>(Arg.Any<Customer>()).Returns(customerResponseDto);
            var expectedResult = (true, customerResponseDto);
            var actualResult = await _sut.AdminSignUp(result);
            Assert.Equal(true, expectedResult.Item1);
            Assert.True(expectedResult.Item1);

        }
        [Fact]
        public async Task AdminSignUp_WhenCustomerPassedInVaild_ReturnFaild()
        {
            var result = new RegisterModel
            {
                FirstName = "test",
                LastName = "test",
                Email = null,
                Address = "testing",
                PhoneNumber = "89790988",
            };
            Customer user = new()
            {
                FirstName = "test",
                LastName = "test",
                Email = null,
                Address = "testing",
                PhoneNumber = "89790988",
            };
            var customerResponseDto = new CustomerResponseDto
            {
                FirstName = "test",
                LastName = "test",
                Email = null,
                Address = "testing",
                PhoneNumber = "89790988",

            };

            _mapper.Map<Customer>(Arg.Any<RegisterModel>()).Returns(user);
            _athenticationRepository.FindByEmailAsync(Arg.Any<string>()).Returns(Task.FromResult<Customer>(null));
            _athenticationRepository.CreateAsync(Arg.Any<Customer>(), Arg.Any<string>()).Returns(IdentityResult.Failed(), IdentityResult.Failed());
            _athenticationRepository.RoleExistsAsync(Arg.Any<string>()).Returns(false);
            _mapper.Map<CustomerResponseDto>(Arg.Any<Customer>()).Returns(customerResponseDto);
            var expectedResult = (false, customerResponseDto);
            var actualResult = await _sut.AdminSignUp(result);
            Assert.False(expectedResult.Item1);

        }

        [Fact]
        public async Task AdminSignUp_WhenCustomerPassedVaild_ReturnUserAlreadyRegistered()
        {
            var result = new RegisterModel
            {
                FirstName = "test",
                LastName = "test",
                Email = "test@example.com",
                Address = "testing",
                PhoneNumber = "89790988",
            };
            Customer user = new()
            {
                FirstName = "test",
                LastName = "test",
                Email = "test@example.com",
                Address = "testing",
                PhoneNumber = "89790988",
            };

            _mapper.Map<Customer>(Arg.Any<RegisterModel>()).Returns(user);
            _athenticationRepository.FindByEmailAsync(Arg.Any<string>()).Returns(user);
            var expectedResult = (true, "User already registered.");
            var actualResult = await _sut.AdminSignUp(result);
            Assert.True(expectedResult.Item1, null);
        }

        [Fact]
        public async Task AdminSignUp_WhenCustomerPassedVaildRole_ReturnSuccess()
        {
            var result = new RegisterModel
            {
                FirstName = "test",
                LastName = "test",
                Email = null,
                Address = "testing",
                PhoneNumber = "89790988",
            };
            Customer user = new()
            {
                FirstName = "test",
                LastName = "test",
                Email = null,
                Address = "testing",
                PhoneNumber = "89790988",
            };
            _mapper.Map<Customer>(Arg.Any<RegisterModel>()).Returns(user);
            _athenticationRepository.FindByEmailAsync(Arg.Any<string>()).Returns(Task.FromResult<Customer>(null));
            _athenticationRepository.CreateAsync(Arg.Any<Customer>(), Arg.Any<string>()).Returns(IdentityResult.Success, IdentityResult.Success);
            _athenticationRepository.RoleExistsAsync(Arg.Any<string>()).Returns(false);
            _athenticationRepository.CreateAsync(Arg.Any<CustomerRole>()).Returns(IdentityResult.Success);
            _athenticationRepository.AddToRoleAsync(Arg.Any<Customer>(), Arg.Any<string>()).Returns(IdentityResult.Failed(), IdentityResult.Failed());
            _athenticationRepository.DeleteAsync(Arg.Any<Customer>()).Returns(IdentityResult.Success);
            var expectedResult1 = "User Role Assignment Failed";
            Tuple<string, string> expectedResult = new(expectedResult1, null);
            var actualResult = await _sut.AdminSignUp(result);
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task AdminSignIn_WhenUserPassedEmailNull_ReturnErrorMessage()
        {
            Customer user = new()
            {
                FirstName = "test",
                LastName = "test",
                Email = null,
                Address = "testing",
                PhoneNumber = "89790988",
            };

            _athenticationRepository.FindByEmailAsync(Arg.Any<string>()).Returns(Task.FromResult<Customer>(null));
            var expeactedResult = "User not found!.";
            var actualResult = await _sut.AdminSignIn(user.Email, user.PasswordHash);
            actualResult.Should().BeEquivalentTo(expeactedResult);
        }

        [Fact]
        public async Task AdminSignIn_WhenUserPassedPasswordNull_ReturnErrorMessage()
        {
            Customer user = new()
            {
                FirstName = "test",
                LastName = "test",
                Email = "user@exapmle.com",
                Address = "testing",
                PhoneNumber = "89790988",
            };
            _athenticationRepository.FindByEmailAsync(Arg.Any<string>()).Returns(user);
            _athenticationRepository.CheckPasswordAsync(Arg.Any<Customer>(), Arg.Any<string>()).Returns(false, false);
            var expeactedResult = "Password mismatch!";
            var actualResult = await _sut.AdminSignIn(user.Email, user.PasswordHash);
            actualResult.Should().BeEquivalentTo(expeactedResult);
        }
    }
}
