using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Hjp.Api.Client.Common;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Utilities;

namespace Hjp.Api.Client.Internal
{
    internal class ApiClientInternal
    {
        private HttpClient httpClient;

        private static readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };
        private static readonly Encoding postBodyEncoding = Encoding.UTF8;
        private static readonly string postBodyContentType = "application/json";

        public ApiClientInternal(string baseUrl)
        {
            this.httpClient = new();
            this.httpClient.BaseAddress = new(baseUrl);
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string route, object? query = null, bool isIncludeNonce = true, CancellationToken cancellationToken = default)
        {
            var headers = RequestUtility.CreateRequestHeaders(isIncludeNonce, null);
            return await GetAsyncInternal<T>(route, query, headers, cancellationToken);
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string route, object body, object? query = null, bool isIncludeNonce = true, CancellationToken cancellationToken = default)
        {
            var headers = RequestUtility.CreateRequestHeaders(isIncludeNonce, null);
            return await PostAsyncInternal<T>(route, query, headers, body, cancellationToken);
        }

        public async Task<ApiResponse<T>> GetWithSignatureAsync<T>(string signature, string route, object? query = null, bool isIncludeNonce = true, CancellationToken cancellationToken = default)
        {
            var headers = RequestUtility.CreateRequestHeaders(isIncludeNonce, signature);
            return await GetAsyncInternal<T>(route, query, headers, cancellationToken);
        }

        public async Task<ApiResponse<T>> PostWithSignatureAsync<T>(string signature, string route, object body, object? query = null, bool isIncludeNonce = true, CancellationToken cancellationToken = default)
        {
            var headers = RequestUtility.CreateRequestHeaders(isIncludeNonce, signature);
            return await PostAsyncInternal<T>(route, query, headers, body, cancellationToken);
        }

        // 以下ヘルパーメソッド

        private async Task<ApiResponse<T>> GetAsyncInternal<T>(string route, object? query, Dictionary<string, string>? headers, CancellationToken cancellationToken)
        {
            var url = route + RequestUtility.ToQueryString(query!);
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            if (headers != null)
            {
                foreach (var (key, value) in headers)
                {
                    request.Headers.Add(key, value);
                }
            }

            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);

            if (response.IsSuccessStatusCode == false)
            {
                return ResponseUtility.CreateErrorResponse<T>(
                    response.StatusCode,
                    await response.Content.ReadAsStringAsync(cancellationToken));
            }


            T? result;
            if (typeof(T) == typeof(string))
            {
                // HACK: 生のstringを返したい場合もある
                object raw = await response.Content.ReadAsStringAsync(cancellationToken);
                result = (T)raw;
            }
            else
            {
                result = await response.Content.ReadFromJsonAsync<T>(ApiClientInternal.jsonOptions, cancellationToken);
            }

            if (result == null)
            {
                throw new InvalidOperationException(Messages.Erros.EmptyResponseBody);
            }

            return ResponseUtility.CreateSuccessResponse<T>(response.StatusCode, result);
        }

        private async Task<ApiResponse<T>> PostAsyncInternal<T>(string route, object? query, Dictionary<string, string>? headers, object? body, CancellationToken cancellationToken)
        {
            var url = route + RequestUtility.ToQueryString(query!);
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (headers != null)
            {
                foreach (var (key, value) in headers)
                {
                    request.Headers.Add(key, value);
                }
            }

            var bodyJson = JsonSerializer.Serialize(body, ApiClientInternal.jsonOptions);
            request.Content = new StringContent(bodyJson, ApiClientInternal.postBodyEncoding, ApiClientInternal.postBodyContentType);

            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);

            if (response.IsSuccessStatusCode == false)
            {
                return ResponseUtility.CreateErrorResponse<T>(
                    response.StatusCode,
                    await response.Content.ReadAsStringAsync(cancellationToken));
            }

            T? result;
            if (typeof(T) == typeof(string))
            {
                // HACK: 生のstringを返したい場合もある
                object raw = await response.Content.ReadAsStringAsync(cancellationToken);
                result = (T)raw;
            }
            else
            {
                result = await response.Content.ReadFromJsonAsync<T>(ApiClientInternal.jsonOptions, cancellationToken);
            }
            if (result == null)
            {
                throw new InvalidOperationException(Messages.Erros.EmptyResponseBody);
            }

            return ResponseUtility.CreateSuccessResponse<T>(response.StatusCode, result);
        }
    }
}

