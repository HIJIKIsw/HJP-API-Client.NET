using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Admin.IntegrationApplications;
using Hjp.Shared.Dto.Admin.Notices;
using Hjp.Shared.Dto.Admin.Notices.Count;
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

        /// <summary>
        /// 全お知らせの件数を取得
        /// </summary>
        Task<ApiResponse<AdminNoticesCountResponse>> GetNoticesCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// お知らせの一覧を取得
        /// </summary>
        Task<ApiResponse<AdminNoticesResponse>> GetNoticeListAsync(AdminNoticesRequest? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// お知らせの詳細情報を取得
        /// </summary>
        Task<ApiResponse<AdminNoticeDetailResponse>> GetNoticeDetailAsync(int noticeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 新規お知らせを作成
        /// </summary>
        Task<ApiResponse<AdminNoticePostResponse>> PostNoticeAsync(AdminNoticePostRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// お知らせを更新
        /// </summary>
        Task<ApiResponse<AdminNoticeEditResponse>> EditNoticeAsync(int noticeId, AdminNoticeEditRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// お知らせを削除
        /// </summary>
        Task<ApiResponse<AdminNoticeRemoveResponse>> RemoveNoticeAsync(int noticeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// 連携アプリの一覧を取得
        /// </summary>
        Task<ApiResponse<AdminIntegrationApplicationsResponse>> GetIntegrationApplicationListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 連携アプリを登録
        /// </summary>
        Task<ApiResponse<AdminIntegrationApplicationPostResponse>> RegisterIntegrationApplicationAsync(AdminIntegrationApplicationPostRequest request, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// 連携アプリを編集
        /// </summary>
        Task<ApiResponse<AdminIntegrationApplicationEditResponse>> EditIntegrationApplicationAsync(int applicationId, AdminIntegrationApplicationEditRequest request, CancellationToken cancellationToken = default);
    }
}