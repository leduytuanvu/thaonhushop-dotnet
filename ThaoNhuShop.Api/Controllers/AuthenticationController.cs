using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using ThaoNhuShop.Contract.Authentication.Login;
using ThaoNhuShop.Contract.Authentication.Register;
using MediatR;
using ThaoNhuShop.Application.Authentication.Commands.Register;
using ThaoNhuShop.Application.Authentication.Queries.Login;
using ThaoNhuShop.Application.Authentication.Common;
using AutoMapper;

namespace ThaoNhuShop.Api.Controllers
{
    [Route("auth")]
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
                result => Ok(_mapper.Map<RegisterResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request){
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> response = await _mediator.Send(query);

            return response.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }
    }
}