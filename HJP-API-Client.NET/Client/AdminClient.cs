using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Admin.Transactions;
using Hjp.Shared.Dto.Admin.Users;
using Hjp.Shared.Dto.Admin.Users.Deposit;
using Hjp.Shared.Dto.Admin.Users.Search;
using Hjp.Shared.Dto.Admin.Users.Withdraw;
using Hjp.Shared.Dto.Auth;
using Hjp.Shared.Enums;

namespace Hjp.Api.Client
{
    internal class AdminClient : IAdminClient
    {
        private readonly ApiClientInternal apiClientInternal;

        private string accessToken = null!;
        private string signature = null!;

        public AdminClient(ApiClientInternal apiClientInternal)
        {
            this.apiClientInternal = apiClientInternal;
        }

        public async Task<ApiResponse<LoginResponse>> LoginWithUserAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var request = new LoginRequest
            {
                AccessToken = accessToken,
                AsPermissionTypeId = PermissionType.Admin
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

        public async Task<ApiResponse<AdminUserResponse>> GetUserProfileAsync(ulong discordUserId, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<AdminUserResponse>(
                signature: this.signature,
                route: $"admin/users/{discordUserId}",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminUserSearchResponse>> SearchUserAsync(AdminUserSearchRequest? request = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
            {
                request = new AdminUserSearchRequest();
            }
            return await this.apiClientInternal.GetWithSignatureAsync<AdminUserSearchResponse>(
                signature: this.signature,
                route: "admin/users/search",
                query: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminUserDepositResponse>> UserDepositAsync(ulong discordUserId, AdminUserDepositRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<AdminUserDepositResponse>(
                signature: this.signature,
                route: $"admin/users/{discordUserId}/deposit",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminUserWithdrawResponse>> UserWithdrawAsync(ulong discordUserId, AdminUserWithdrawRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<AdminUserWithdrawResponse>(
                signature: this.signature,
                route: $"admin/users/{discordUserId}/withdraw",
                body: request,
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminTransactionsResponse>> GetTransactionsAsync(AdminTransactionsRequest? request = null, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<AdminTransactionsResponse>(
                signature: this.signature,
                route: "admin/transactions",
                query: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }
    }
}