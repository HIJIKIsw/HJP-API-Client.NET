using System.Net;

namespace Hjp.Api.Client.Dto
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}
