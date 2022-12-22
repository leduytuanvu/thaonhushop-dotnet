using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ThaoNhuShop.Application.Authentication.Commands.Register;
using ThaoNhuShop.Application.Authentication.Queries.Login;
using ThaoNhuShop.Application.Authentication.Common;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ThaoNhuShop.Contract.Authentication.Request;
using ThaoNhuShop.Contract.Authentication.Response;

namespace ThaoNhuShop.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class Authentication : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public Authentication(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request){
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult?> response = await _mediator.Send(command);

            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.Created, message: "Successfully", data: _mapper.Map<AuthenticationResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request){
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> response = await _mediator.Send(query);

            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.OK, message: "Successfully", data: _mapper.Map<AuthenticationResponse>(result)),
                errors => Problem(errors)
            );
        }
    }
}