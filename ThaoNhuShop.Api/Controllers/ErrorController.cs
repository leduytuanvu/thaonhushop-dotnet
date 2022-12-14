using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ThaoNhuShop.Application.Common.Errors;

namespace ThaoNhuShop.Api.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                IServiceException serviceException => (serviceException.StatusCode, serviceException.ErrorMessage),
                _ => (HttpStatusCode.InternalServerError, "Something went wrong"),
            };

            return Problem(statusCode: (int)statusCode, title: message);
        } 
    }
}