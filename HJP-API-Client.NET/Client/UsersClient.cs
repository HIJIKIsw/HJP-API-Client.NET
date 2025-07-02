using System.Net.Http.Json;
using System.Text.Json;
using Hjp.Api.Client.Common;
using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Internal;
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
        private readonly string baseUrl;
        private readonly string apiKey;
        private readonly ulong discordUserId;

        private readonly ApiClientInternal apiClientInternal;

        public UsersClient(ApiClientInternal apiClientInternal, string baseUrl, string apiKey, ulong discordUserId)
        {
            this.apiClientInternal = apiClientInternal;
            this.baseUrl = baseUrl;
            this.apiKey = apiKey;
            this.discordUserId = discordUserId;
        }

        public async Task<ApiResponse<UserResponse>> GetProfileAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<UserResponse>(this.discordUserId, "users/me", null, cancellationToken);
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