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
using Hjp.Shared.Dto.Routes.Lottery;
using Hjp.Shared.Dto.Auth;
using Hjp.Shared.Enums;
using Hjp.Api.Client.Utilities;
using Hjp.Shared.Dto.Me.Lottery;
using Hjp.Shared.Dto.Users.Search;

namespace Hjp.Api.Client
{
    internal class UsersClient : IUsersClient
    {
        private readonly ApiClientInternal apiClientInternal;

        private string accessToken = null!;
        private string signature = null!;

        public UsersClient(ApiClientInternal apiClientInternal)
        {
            this.apiClientInternal = apiClientInternal;
        }

        public async Task<ApiResponse<LoginResponse>> LoginAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var request = new LoginRequest
            {
                AccessToken = accessToken,
                AsPermissionTypeId = PermissionType.User
            };
            var result = await this.apiClientInternal.PostAsync<LoginResponse>("auth/login", request, null, true, cancellationToken);
            if (result.IsSuccess == true)
            {
                this.accessToken = accessToken;
                this.signature = result.Result?.Signature!;
            }
            else
            {
                this.accessToken = null!;
                this.signature = null!;
            }
            return result;
        }

        private async Task AutoReloginWhenTokenExpiredAsync(CancellationToken cancellationToken = default)
        {
            var jwtPayload = JwtDecoder.DecodePayload(this.signature);
            if (jwtPayload.IsExpired() == false)
            {
                return;
            }
            await this.LoginAsync(this.accessToken, cancellationToken);
        }

        public async Task<ApiResponse<UserResponse>> GetProfileAsync(CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<UserResponse>(
                signature: this.signature,
                route: "me",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserBalanceResponse>> GetBalanceAsync(CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<UserBalanceResponse>(
                signature: this.signature,
                route: "me/balance",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserTransactionsResponse>> GetTransactionsAsync(UserTransactionsRequest? query = null, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<UserTransactionsResponse>(
                signature: this.signature,
                route: "me/transactions",
                query: query,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserStatsResponse>> GetStatsAsync(CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<UserStatsResponse>(
                signature: this.signature,
                route: "me/stats",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserDepositResponse>> DepositAsync(UserDepositRequest request, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

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
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

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
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<UserTransferResponse>(
                signature: this.signature,
                route: "me/transfer",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserLotteryResponse>> DrawLotteryAsync(CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<UserLotteryResponse>(
                signature: this.signature,
                route: "me/lottery/draw",
                body: null!,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<LotteryBankResponse>> GetLotteryBankAsync(CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<LotteryBankResponse>(
                signature: this.signature,
                route: "lottery/bank",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<UserSearchResponse>> SearchUserAsync(UserSearchRequest? request = null, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

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
    }
}