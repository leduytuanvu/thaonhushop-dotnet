using Microsoft.AspNetCore.Mvc;
using ThaoNhuShop.Application.Common.Interfaces.Services.Authentication;
using ThaoNhuShop.Contract.Authentication.Login;
using ThaoNhuShop.Contract.Authentication.Register;

namespace ThaoNhuShop.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class Authentication : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public Authentication(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request){
            var authResult = _authenticationService.Register(
                phone: request.Phone,
                password: request.Password,
                rePassword: request.RePassword,
                fullName: request.FullName
            );
            var response = new RegisterResponse(
                Id: authResult.Id,
                Phone: authResult.Phone,
                FullName: authResult.FullNName
            );
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request){
            var authResult = _authenticationService.Login(
                phone: request.Phone,
                password: request.Password
            );

            var response = new LoginResponse(
                Id: authResult.Id,
                Phone: authResult.Phone,
                FullName: authResult.FullNName
            );
            return Ok(response);
        }
    }
}