using CoreApiResponse;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThaoNhuShop.Api.Http;

namespace ThaoNhuShop.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiController : BaseController
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if(errors.Count is 0){
                return Problem();
            }           

            // CATCH ERROR FLUENT VALIDATION
            if (errors.All(error => error.Type == ErrorType.Validation))
            {                    
                return ApplicationProblem(errors);
            }

            // CATCH ERROR IN DOMAIN
            // if (errors.All(error => error.NumericType == 400))
            // {
            //     return ValidationProblem(errors);
            // }

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            return DomainProblem(errors[0]);
        }

        private IActionResult DomainProblem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            return CustomResult(code: (System.Net.HttpStatusCode)statusCode, message: "Something went wrong while processing the output", data: error);
        }

        private IActionResult ApplicationProblem(List<Error> errors)
        {
            // var modelStateDictionary = new ModelStateDictionary();

            // foreach (var error in errors)
            // {
            //     modelStateDictionary.AddModelError(error.Code, error.Description);
            // }

            // return ValidationProblem(modelStateDictionary);
            var statusCode = errors[0].Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            return CustomResult(code: (System.Net.HttpStatusCode)statusCode, message: "Something went wrong while processing the input", data: errors[0]);
        }
    }
}