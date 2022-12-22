using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThaoNhuShop.Application.Category.Queries.GetById;
using Entity = ThaoNhuShop.Domain.Entities;
using ThaoNhuShop.Contract.Category.Response;
using ThaoNhuShop.Application.Category.Queries.GetAll;
using ThaoNhuShop.Application.Category.Commands.CreateNew;
using ThaoNhuShop.Contract.Category.Request;
using ThaoNhuShop.Application.Category.Commands.Delete;

namespace ThaoNhuShop.Api.Controllers
{
    [Route("categories")]
    public class CategorieController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CategorieController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuery();

            ErrorOr<List<Entity.Category>> response = await _mediator.Send(query);
            
            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.OK, message: "Successfully", data: _mapper.Map<List<CategoryResponse>>(result)),
                errors => Problem(errors)
            );
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var query = new GetByIdQuery(Id: Id);

            ErrorOr<Entity.Category> response = await _mediator.Send(query);

            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.OK, message: "Successfully", data: _mapper.Map<CategoryResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateNewCategoryRequest request)
        {
            var command = _mapper.Map<CreateNewCommand>(request);

            ErrorOr<Entity.Category> response = await _mediator.Send(command);

            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.Created, message: "Successfully", data: _mapper.Map<CategoryResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCommand(Id: id);

            ErrorOr<Entity.Category> response = await _mediator.Send(command);

            return response.Match(
                result => CustomResult(code: System.Net.HttpStatusCode.OK, message: "Successfully", data: _mapper.Map<CategoryResponse>(result)),
                errors => Problem(errors)
            );
        }
    }
}