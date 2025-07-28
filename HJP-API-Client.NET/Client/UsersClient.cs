using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Me.Balance;
using Hjp.Shared.Dto.Me.Deposit;
using Hjp.Shared.Dto.Me;
using Hjp.Shared.Dto.Me.Stats;
using Hjp.Shared.Dto.Me.Transactions;
using Hjp.Shared.Dto.Me.Transfer;
using Hjp.Shared.Dto.Me.Withdraw;
using Hjp.Shared.Dto.Lottery;
using Hjp.Shared.Dto.Me.Lottery;
using Hjp.Shared.Dto.Users.Search;
using Hjp.Shared.Dto.Notices.Count;
using Hjp.Shared.Dto.Notices;
using Hjp.Shared.Dto.Me.Balance.History;

namespace Hjp.Api.Client
{
    internal class UsersClient : BaseChildClient, IUsersClient
    {
        public UsersClient(ApiClientInternal apiClientInternal, string signature)
        : base(apiClientInternal, signature)
        {
            // Nothind to do.
        }

        public async Task<ApiResponse<UserResponse>> GetProfileAsync(CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<UserResponse>(
                signature: this.signature,
                route: "me",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserBalanceResponse>> GetBalanceAsync(CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<UserBalanceResponse>(
                signature: this.signature,
                route: "me/balance",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserBalanceHistoryResponse>> GetBalanceHistoryAsync(UserBalanceHistoryRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return await this.apiClientInternal.GetWithSignatureAsync<UserBalanceHistoryResponse>(
                signature: this.signature,
                route: "me/balance/history",
                query: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserTransactionsResponse>> GetTransactionsAsync(UserTransactionsRequest? query = null, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<UserTransactionsResponse>(
                signature: this.signature,
                route: "me/transactions",
                query: query,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserStatsResponse>> GetStatsAsync(CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<UserStatsResponse>(
                signature: this.signature,
                route: "me/stats",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserDepositResponse>> DepositAsync(UserDepositRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

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
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

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
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<UserTransferResponse>(
                signature: this.signature,
                route: "me/transfer",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserLotteryResponse>> DrawLotteryAsync(UserLotteryRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<UserLotteryResponse>(
                signature: this.signature,
                route: "me/lottery/draw",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<LotteryBankResponse>> GetLotteryBankAsync(CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<LotteryBankResponse>(
                signature: this.signature,
                route: "lottery/bank",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserSearchResponse>> SearchUserAsync(UserSearchRequest? request = null, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            if (request == null)
            {
                request = new UserSearchRequest();
            }
            return await this.apiClientInternal.GetWithSignatureAsync<UserSearchResponse>(
                signature: this.signature,
                route: "users/search",
                query: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<NoticesCountResponse>> GetNoticesCountAsync(CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<NoticesCountResponse>(
                signature: this.signature,
                route: "notices/count",
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<NoticesResponse>> GetNoticeListAsync(NoticesRequest? request = null, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            if (request == null)
            {
                request = new();
            }
            return await this.apiClientInternal.GetWithSignatureAsync<NoticesResponse>(
                signature: this.signature,
                route: "notices",
                query: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<NoticeDetailResponse>> GetNoticeDetailAsync(int noticeId, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<NoticeDetailResponse>(
                signature: this.signature,
                route: $"notices/{noticeId}",
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }
    }
}