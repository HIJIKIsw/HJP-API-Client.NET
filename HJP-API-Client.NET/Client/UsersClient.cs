using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Users.Me.Balance;
using Hjp.Shared.Dto.Users.Me.Deposit;
using Hjp.Shared.Dto.Users.Me;
using Hjp.Shared.Dto.Users.Me.Stats;
using Hjp.Shared.Dto.Users.Me.Transactions;
using Hjp.Shared.Dto.Users.Me.Transfer;
using Hjp.Shared.Dto.Users.Me.Withdraw;
using Hjp.Shared.Dto.Routes.Users.Me.Lottery;
using Hjp.Shared.Dto.Routes.Lottery;

namespace Hjp.Api.Client
{
    internal class UsersClient : IUsersClient
    {
        private readonly ulong discordUserId;

        private readonly ApiClientInternal apiClientInternal;

        public UsersClient(ApiClientInternal apiClientInternal, ulong discordUserId)
        {
            this.apiClientInternal = apiClientInternal;
            this.discordUserId = discordUserId;
        }

        public async Task<ApiResponse<UserResponse>> GetProfileAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<UserResponse>(
                discordUserId: this.discordUserId,
                route: "users/me",
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserBalanceResponse>> GetBalanceAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<UserBalanceResponse>(
                discordUserId: this.discordUserId,
                route: "users/me/balance",
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserTransactionsResponse>> GetTransactionsAsync(UserTransactionsRequest? query = null, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<UserTransactionsResponse>(
                discordUserId: this.discordUserId,
                route: "users/me/transactions",
                query: query,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserStatsResponse>> GetStatsAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<UserStatsResponse>(
                discordUserId: this.discordUserId,
                route: "users/me/stats",
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserDepositResponse>> DepositAsync(UserDepositRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<UserDepositResponse>(
                discordUserId: this.discordUserId,
                route: "users/me/deposit",
                body: request,
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserWithdrawResponse>> WithdrawAsync(UserWithdrawRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<UserWithdrawResponse>(
                discordUserId: this.discordUserId,
                route: "users/me/withdraw",
                body: request,
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserTransferResponse>> TransferAsync(UserTransferRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<UserTransferResponse>(
                discordUserId: this.discordUserId,
                route: "users/me/transfer",
                body: request,
                query: null,
                cancellationToken: cancellationToken);
        }

        public Task<ApiResponse<UserLotteryResponse>> Lottery(CancellationToken cancellationToken = default)
        {
            return this.apiClientInternal.PostWithSignatureAsync<UserLotteryResponse>(
                discordUserId: this.discordUserId,
                route: "users/me/lottery",
                body: null!,
                query: null,
                cancellationToken: cancellationToken);
        }

        public Task<ApiResponse<LotteryBankResponse>> GetLotteryBank(CancellationToken cancellationToken = default)
        {
            return this.apiClientInternal.GetWithSignatureAsync<LotteryBankResponse>(
                discordUserId: this.discordUserId,
                route: "lottery/bank",
                query: null,
                cancellationToken: cancellationToken);
        }
    }
}