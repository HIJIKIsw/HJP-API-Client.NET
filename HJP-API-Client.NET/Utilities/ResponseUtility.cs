using System.Net;
using Hjp.Api.Client.Dto;

namespace Hjp.Api.Client.Utilities
{
    public static class ResponseUtility
    {
        public static ApiResponse<T> CreateSuccessResponse<T>(HttpStatusCode statusCode, T result, string? message = null)
        {
            return new ApiResponse<T>()
            {
                IsSuccess = true,
                StatusCode = statusCode,
                Message = message,
                Result = result
            };
        }

        public static ApiResponse<T> CreateErrorResponse<T>(HttpStatusCode statusCode, string message)
        {
            return new ApiResponse<T>()
            {
                IsSuccess = false,
                StatusCode = statusCode,
                Message = message
            };
        }
    }
}