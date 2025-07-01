using System.Net.Http.Json;
using System.Text.Json;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Utilities;
using Hjp.Shared.Dto.Users.Login;

namespace Hjp.Api.Client
{
    internal class UsersClient : IUsersClient
    {
        private readonly HttpClient httpClient;

        public UsersClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ApiResponse<UserLoginResponse>> LoginAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var postData = new
            {
                AccessToken = accessToken
            };
            var response = await this.httpClient.PostAsJsonAsync(
                "/users/login",
                postData,
                jsonOptions,
                cancellationToken);
            if (response.IsSuccessStatusCode == false)
            {
                return ResponseUtility.CreateErrorResponse<UserLoginResponse>(response.StatusCode, await response.Content.ReadAsStringAsync());
            }
            var result = await response.Content.ReadFromJsonAsync<UserLoginResponse>(jsonOptions, cancellationToken);
            if (result == null)
            {
                throw new InvalidOperationException("Empty response body");
            }

            return ResponseUtility.CreateSuccessResponse<UserLoginResponse>(response.StatusCode, result);
        }
    }
}