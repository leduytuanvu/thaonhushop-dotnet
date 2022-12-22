using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThaoNhuShop.Application.Brand.Queries.GetById;
using Entity = ThaoNhuShop.Domain.Entities;
using ThaoNhuShop.Contract.Brand.Response;
using ThaoNhuShop.Application.Brand.Queries.GetAll;
using ThaoNhuShop.Application.Brand.Commands.CreateNew;
using ThaoNhuShop.Contract.Brand.Request;
using ThaoNhuShop.Application.Brand.Commands.Delete;

namespace ThaoNhuShop.Api.Controllers
{
    [Route("brands")]
    public class BrandController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public BrandController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuery();

            ErrorOr<List<Entity.Brand>> response = await _mediator.Send(query);
            
            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.OK, message: "Successfully", data: _mapper.Map<List<BrandResponse>>(result)),
                errors => Problem(errors)
            );
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetByIdQuery(Id: Id);

            ErrorOr<Entity.Brand> response = await _mediator.Send(query);

            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.OK, message: "Successfully", data: _mapper.Map<BrandResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateNewBrandRequest request)
        {
            var command = _mapper.Map<CreateNewCommand>(request);

            ErrorOr<Entity.Brand> response = await _mediator.Send(command);

            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.Created, message: "Successfully", data: _mapper.Map<BrandResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCommand(Id: id);

            ErrorOr<Entity.Brand> response = await _mediator.Send(command);

            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.OK, message: "Successfully", data: _mapper.Map<BrandResponse>(result)),
                errors => Problem(errors)
            );
        }
    }
}