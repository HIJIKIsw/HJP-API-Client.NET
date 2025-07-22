using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Api.Client.Utilities;
using Hjp.Shared.Dto.Admin.Notices;
using Hjp.Shared.Dto.Admin.Notices.Count;
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

        public async Task<ApiResponse<LoginResponse>> LoginAsync(string accessToken, CancellationToken cancellationToken = default)
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

        private async Task AutoReloginWhenTokenExpiredAsync(CancellationToken cancellationToken = default)
        {
            var jwtPayload = JwtDecoder.DecodePayload(this.signature);
            if (jwtPayload.IsExpired() == false)
            {
                return;
            }
            await this.LoginAsync(this.accessToken, cancellationToken);
        }

        public async Task<ApiResponse<AdminUserResponse>> GetUserProfileAsync(ulong discordUserId, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<AdminUserResponse>(
                signature: this.signature,
                route: $"admin/users/{discordUserId}",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminUserSearchResponse>> SearchUserAsync(AdminUserSearchRequest? request = null, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

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
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

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
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

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
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<AdminTransactionsResponse>(
                signature: this.signature,
                route: "admin/transactions",
                query: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticesCountResponse>> GetNoticesCountAsync(CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<AdminNoticesCountResponse>(
                signature: this.signature,
                route: "admin/notices/count",
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticesResponse>> GetNoticeListAsync(AdminNoticesRequest? request = null, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            if (request == null)
            {
                request = new();
            }
            return await this.apiClientInternal.GetWithSignatureAsync<AdminNoticesResponse>(
                signature: this.signature,
                route: "admin/notices",
                query: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticeDetailResponse>> GetNoticeDetailAsync(int noticeId, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<AdminNoticeDetailResponse>(
                signature: this.signature,
                route: $"admin/notices/{noticeId}",
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticePostResponse>> PostNoticeAsync(AdminNoticePostRequest request, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<AdminNoticePostResponse>(
                signature: this.signature,
                route: "admin/notices",
                body: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticeEditResponse>> EditNoticeAsync(int noticeId, AdminNoticesEditRequest request, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.PutWithSignatureAsync<AdminNoticeEditResponse>(
                signature: this.signature,
                route: $"admin/notices/{noticeId}",
                body: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticesRemoveResponse>> DeleteNoticeAsync(int noticeId, CancellationToken cancellationToken = default)
        {
            await this.AutoReloginWhenTokenExpiredAsync(cancellationToken);

            return await this.apiClientInternal.DeleteWithSignatureAsync<AdminNoticesRemoveResponse>(
                signature: this.signature,
                route: $"admin/notices/{noticeId}",
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }
    }
}