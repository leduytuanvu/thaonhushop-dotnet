using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThaoNhuShop.Application.Product.Commands.CreateNew;
using ThaoNhuShop.Application.Product.Queries.GetAll;
using ThaoNhuShop.Contract.Product.Request;
using ThaoNhuShop.Contract.Product.Response;
using Entity = ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Api.Controllers
{
    [Route("products")]
    public class ProductController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public ProductController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuery();

            ErrorOr<List<Entity.Product>> response = await _mediator.Send(query);
            
            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.OK, message: "Successfully", data: _mapper.Map<List<ProductResponse>>(result)),
                errors => Problem(errors)
            );
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNew(CreateNewProductRequest request)
        {
            var command = _mapper.Map<CreateNewCommand>(request);

            ErrorOr<Entity.Product> response = await _mediator.Send(command);
            
            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.OK, message: "Successfully", data: _mapper.Map<ProductResponse>(result)),
                errors => Problem(errors)
            );
        }
    }
}