using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Admin.IntegrationApplications;
using Hjp.Shared.Dto.Admin.Notices;
using Hjp.Shared.Dto.Admin.Notices.Count;
using Hjp.Shared.Dto.Admin.Transactions;
using Hjp.Shared.Dto.Admin.Users;
using Hjp.Shared.Dto.Admin.Users.Deposit;
using Hjp.Shared.Dto.Admin.Users.Search;
using Hjp.Shared.Dto.Admin.Users.Withdraw;

namespace Hjp.Api.Client
{
    internal class AdminClient : BaseChildClient, IAdminClient
    {
        public AdminClient(ApiClientInternal apiClientInternal, string signature)
        : base(apiClientInternal, signature)
        {
            // Nothind to do.
        }

        public async Task<ApiResponse<AdminUserResponse>> GetUserProfileAsync(ulong discordUserId, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<AdminUserResponse>(
                signature: this.signature,
                route: $"admin/users/{discordUserId}",
                query: null,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminUserSearchResponse>> SearchUserAsync(AdminUserSearchRequest? request = null, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

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
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

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
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

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
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<AdminTransactionsResponse>(
                signature: this.signature,
                route: "admin/transactions",
                query: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticesCountResponse>> GetNoticesCountAsync(CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<AdminNoticesCountResponse>(
                signature: this.signature,
                route: "admin/notices/count",
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticesResponse>> GetNoticeListAsync(AdminNoticesRequest? request = null, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

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
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<AdminNoticeDetailResponse>(
                signature: this.signature,
                route: $"admin/notices/{noticeId}",
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticePostResponse>> PostNoticeAsync(AdminNoticePostRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<AdminNoticePostResponse>(
                signature: this.signature,
                route: "admin/notices",
                body: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticeEditResponse>> EditNoticeAsync(int noticeId, AdminNoticeEditRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PutWithSignatureAsync<AdminNoticeEditResponse>(
                signature: this.signature,
                route: $"admin/notices/{noticeId}",
                body: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminNoticeRemoveResponse>> RemoveNoticeAsync(int noticeId, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.DeleteWithSignatureAsync<AdminNoticeRemoveResponse>(
                signature: this.signature,
                route: $"admin/notices/{noticeId}",
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminIntegrationApplicationsResponse>> GetIntegrationApplicationListAsync(CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.GetWithSignatureAsync<AdminIntegrationApplicationsResponse>(
                signature: this.signature,
                route: $"admin/integration-applications",
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminIntegrationApplicationRegisterResponse>> RegisterIntegrationApplicationAsync(AdminIntegrationApplicationRegisterRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PostWithSignatureAsync<AdminIntegrationApplicationRegisterResponse>(
                signature: this.signature,
                route: $"admin/integration-applications",
                body: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminIntegrationApplicationEditResponse>> EditIntegrationApplicationAsync(int applicationId, AdminIntegrationApplicationEditRequest request, CancellationToken cancellationToken = default)
        {
            await this.InvokeOnBeforeMethodAsync(cancellationToken);

            return await this.apiClientInternal.PutWithSignatureAsync<AdminIntegrationApplicationEditResponse>(
                signature: this.signature,
                route: $"admin/integration-applications/{applicationId}",
                body: request,
                isIncludeNonce: true,
                cancellationToken: cancellationToken);
        }
    }
}