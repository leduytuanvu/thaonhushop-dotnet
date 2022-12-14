using System.Diagnostics;
using System.Net;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using ThaoNhuShop.Api.Http;

namespace ThaoNhuShop.Api.Common.Errors
{
    public class ThaoNhuShopProblemDetailsFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _option;

        public ThaoNhuShopProblemDetailsFactory(IOptions<ApiBehaviorOptions> option)
        {
            _option = option?.Value ?? throw new ArgumentNullException(nameof(option));
        }

        public override ProblemDetails CreateProblemDetails(
            HttpContext httpContext,
            int? statusCode = null,
            string? title = null,
            string? type = null,
            string? detail = null,
            string? instance = null
        ){
            statusCode ??= (int)HttpStatusCode.InternalServerError;
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance
            };
            ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);
            return problemDetails;
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(
            HttpContext httpContext,
            ModelStateDictionary modelStateDictionary,
            int? statusCode = null,
            string? title = null,
            string? type = null,
            string? detail = null,
            string? instance = null
        ){
            if(modelStateDictionary == null){
                throw new ArgumentException(nameof(modelStateDictionary));
            }

            statusCode ??= (int)HttpStatusCode.BadRequest;

            var problemDetails = new ValidationProblemDetails(modelStateDictionary)
            {
                Status = statusCode,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            if(title!=null){
                problemDetails.Title = title;
            }

            ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);
            return problemDetails;
        }

        private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
        {
            problemDetails.Status ??= statusCode;
            if (_option.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
            {
                problemDetails.Type ??= clientErrorData.Link;
                problemDetails.Title ??= clientErrorData.Title;
            }

            var tradeId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
            if (tradeId != null)
            {
                problemDetails.Extensions["traceId"] = tradeId;
            }

            var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;
            if(errors is not null){
                problemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));
            } 
        }
    }
}