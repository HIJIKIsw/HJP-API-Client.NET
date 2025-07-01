using System.Text.Json;
using Hjp.Api.Client.Dto;
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
        private readonly ulong discordUserId;

        public UsersClient(HttpClient httpClient, ulong discordUserId)
        {
            this.httpClient = httpClient;
            this.discordUserId = discordUserId;
        }

        public Task<ApiResponse<UserResponse>> GetProfileAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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