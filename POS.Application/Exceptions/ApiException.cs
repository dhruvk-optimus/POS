using System.Net;

namespace POS.Application.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ApiException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
