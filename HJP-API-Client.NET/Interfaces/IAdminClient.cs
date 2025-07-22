using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Admin.Transactions;
using Hjp.Shared.Dto.Admin.Users;
using Hjp.Shared.Dto.Admin.Users.Deposit;
using Hjp.Shared.Dto.Admin.Users.Search;
using Hjp.Shared.Dto.Admin.Users.Withdraw;

namespace Hjp.Api.Client.Interfaces
{
    public interface IAdminClient
    {
        /// <summary>
        /// ユーザ情報を取得
        /// </summary>
        /// <param name="discordUserId">取得対象DiscordユーザID</param>
        Task<ApiResponse<AdminUserResponse>> GetUserProfileAsync(ulong discordUserId, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザを検索
        /// </summary>
        /// <param name="request">検索条件 (省略時はすべて取得)</param>
        Task<ApiResponse<AdminUserSearchResponse>> SearchUserAsync(AdminUserSearchRequest? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの入金
        /// </summary>
        /// <param name="discordUserId">入金対象DiscordユーザID</param>
        /// <param name="request">入金情報</param>
        Task<ApiResponse<AdminUserDepositResponse>> UserDepositAsync(ulong discordUserId, AdminUserDepositRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの出金
        /// </summary>
        /// <param name="discordUserId">出金対象DiscordユーザID</param>
        /// <param name="request">出金情報</param>
        Task<ApiResponse<AdminUserWithdrawResponse>> UserWithdrawAsync(ulong discordUserId, AdminUserWithdrawRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 取引情報を取得
        /// </summary>
        /// <param name="request">取得フィルタ条件</param>
        Task<ApiResponse<AdminTransactionsResponse>> GetTransactionsAsync(AdminTransactionsRequest? request = null, CancellationToken cancellationToken = default);
    }
}