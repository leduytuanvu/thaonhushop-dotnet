using System.Net;

namespace ThaoNhuShop.Application.Common.Errors
{
    public class DuplicatePhoneException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Phone number already exists";
    }
}