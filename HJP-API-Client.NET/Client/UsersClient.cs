using System.Net.Http.Json;
using System.Text.Json;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Utilities;
using Hjp.Shared.Dto.Users.Me;

namespace Hjp.Api.Client
{
    internal class UsersClient : IUsersClient
    {
        private readonly HttpClient httpClient;

        public UsersClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ApiResponse<UserResponse>> LoginAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var postData = new
            {
                AccessToken = accessToken
            };
            var postBody = JsonSerializer.Serialize(postData);
            using var content = new StringContent(postBody, System.Text.Encoding.UTF8, "application/json");
            var responseRaw = await this.httpClient.PostAsync("/users/login", content);
            if (responseRaw.IsSuccessStatusCode == false)
            {
                return ResponseUtility.CreateErrorResponse<UserResponse>(responseRaw.StatusCode, await responseRaw.Content.ReadAsStringAsync());
            }
            var responseStream = await responseRaw.Content.ReadAsStreamAsync();
            var jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var result = await responseRaw.Content.ReadFromJsonAsync<UserResponse>(jsonOptions, cancellationToken);
            if (result == null)
            {
                throw new InvalidOperationException("Empty response body");
            }

            return ResponseUtility.CreateSuccessResponse<UserResponse>(responseRaw.StatusCode, result);
        }
    }
}