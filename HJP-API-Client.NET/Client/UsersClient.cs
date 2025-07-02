using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;
using Hjp.Api.Client.Common;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Utilities;
using Hjp.Shared.Dto.Users.Balance;
using Hjp.Shared.Dto.Users.Deposit;
using Hjp.Shared.Dto.Users.Me;
using Hjp.Shared.Dto.Users.Stats;
using Hjp.Shared.Dto.Users.Transactions;
using Hjp.Shared.Dto.Users.Transfer;
using Hjp.Shared.Dto.Users.Withdraw;

namespace Hjp.Api.Client
{
    internal class UsersClient : IUsersClient
    {
        private readonly HttpClient httpClient;

        public UsersClient(string baseUrl, string apiKey, ulong discordUserId)
        {
            this.httpClient = new();
            this.httpClient.BaseAddress = new Uri(baseUrl);
            this.httpClient.DefaultRequestHeaders.Add(Constants.DiscordUserIdHeaderName, discordUserId.ToString());
        }

        public async Task<ApiResponse<UserResponse>> GetProfileAsync(CancellationToken cancellationToken = default)
        {
            // TOOD: リクエスト処理を共通化したい
            var jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var response = await this.httpClient.GetAsync(
                "users/me",
                cancellationToken);
            if (response.IsSuccessStatusCode == false)
            {
                return ResponseUtility.CreateErrorResponse<UserResponse>(
                    response.StatusCode,
                    await response.Content.ReadAsStringAsync(cancellationToken));
            }
            var result = await response.Content.ReadFromJsonAsync<UserResponse>(jsonOptions, cancellationToken);
            if (result == null)
            {
                throw new InvalidOperationException(Messages.Erros.EmptyResponseBody);
            }

            return ResponseUtility.CreateSuccessResponse<UserResponse>(response.StatusCode, result);
        }

        public Task<ApiResponse<UserBalanceResponse>> GetBalanceAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserTransactionsResponse>> GetTransactionsAsync(UserTransactionsRequest? query = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserStatsResponse>> GetStatsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserDepositResponse>> DepositAsync(UserDepositRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserWithdrawResponse>> WithdrawAsync(UserWithdrawRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserTransferResponse>> TransferAsync(UserTransferRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}