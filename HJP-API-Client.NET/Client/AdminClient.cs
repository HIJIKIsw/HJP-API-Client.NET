using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Admin.Transactions;
using Hjp.Shared.Dto.Admin.Users;
using Hjp.Shared.Dto.Admin.Users.Deposit;
using Hjp.Shared.Dto.Admin.Users.Withdraw;

namespace Hjp.Api.Client
{
    internal class AdminClient : IAdminClient
    {
        private readonly ulong discordUserId;

        private readonly ApiClientInternal apiClientInternal;

        public AdminClient(ApiClientInternal apiClientInternal, ulong discordUserId)
        {
            this.apiClientInternal = apiClientInternal;
            this.discordUserId = discordUserId;
        }

        public async Task<ApiResponse<AdminUserResponse>> GetUserProfileAsync(ulong discordUserId, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<AdminUserResponse>(
                discordUserId: this.discordUserId,
                route: $"admin/users/{discordUserId}",
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminUserDepositResponse>> UserDepositAsync(ulong discordUserId, AdminUserDepositRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<AdminUserDepositResponse>(
                discordUserId: this.discordUserId,
                route: $"admin/users/{discordUserId}/deposit",
                body: request,
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminUserWithdrawResponse>> UserWithdrawAsync(ulong discordUserId, AdminUserWithdrawRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<AdminUserWithdrawResponse>(
                discordUserId: this.discordUserId,
                route: $"admin/users/{discordUserId}/withdraw",
                body: request,
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<AdminTransactionsResponse>> GetTransactionsAsync(AdminTransactionsRequest? request = null, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<AdminTransactionsResponse>(
                discordUserId: this.discordUserId,
                route: "admin/transactions",
                query: request,
                cancellationToken: cancellationToken);
        }
    }
}