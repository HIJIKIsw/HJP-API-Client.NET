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
        private readonly string signature;

        private readonly ApiClientInternal apiClientInternal;

        public UsersClient(ApiClientInternal apiClientInternal, string signature)
        {
            this.apiClientInternal = apiClientInternal;
            this.signature = signature;
        }

        public async Task<ApiResponse<UserResponse>> GetProfileAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<UserResponse>(
                signature: this.signature,
                route: "me",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserBalanceResponse>> GetBalanceAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<UserBalanceResponse>(
                signature: this.signature,
                route: "me/balance",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserTransactionsResponse>> GetTransactionsAsync(UserTransactionsRequest? query = null, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<UserTransactionsResponse>(
                signature: this.signature,
                route: "me/transactions",
                query: query,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserStatsResponse>> GetStatsAsync(CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<UserStatsResponse>(
                signature: this.signature,
                route: "me/stats",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserDepositResponse>> DepositAsync(UserDepositRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<UserDepositResponse>(
                signature: this.signature,
                route: "me/deposit",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserWithdrawResponse>> WithdrawAsync(UserWithdrawRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<UserWithdrawResponse>(
                signature: this.signature,
                route: "me/withdraw",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserTransferResponse>> TransferAsync(UserTransferRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<UserTransferResponse>(
                signature: this.signature,
                route: "me/transfer",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public Task<ApiResponse<UserLotteryResponse>> DrawLottery(CancellationToken cancellationToken = default)
        {
            return this.apiClientInternal.PostWithSignatureAsync<UserLotteryResponse>(
                signature: this.signature,
                route: "me/lottery/draw",
                body: null!,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public Task<ApiResponse<LotteryBankResponse>> GetLotteryBank(CancellationToken cancellationToken = default)
        {
            return this.apiClientInternal.GetWithSignatureAsync<LotteryBankResponse>(
                signature: this.signature,
                route: "lottery/bank",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }
    }
}