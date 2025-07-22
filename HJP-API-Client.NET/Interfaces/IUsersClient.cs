using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Me.Balance;
using Hjp.Shared.Dto.Me.Deposit;
using Hjp.Shared.Dto.Me;
using Hjp.Shared.Dto.Me.Stats;
using Hjp.Shared.Dto.Me.Transactions;
using Hjp.Shared.Dto.Me.Transfer;
using Hjp.Shared.Dto.Me.Withdraw;
using Hjp.Shared.Dto.Me.Lottery;
using Hjp.Shared.Dto.Lottery;
using Hjp.Shared.Dto.Users.Search;
using Hjp.Shared.Dto.Notices;
using Hjp.Shared.Dto.Notices.Count;

namespace Hjp.Api.Client.Interfaces
{
    public interface IUsersClient
    {
        /// <summary>
        /// ユーザ情報を取得
        /// </summary>
        Task<ApiResponse<UserResponse>> GetProfileAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの残高を取得
        /// </summary>
        Task<ApiResponse<UserBalanceResponse>> GetBalanceAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの取引履歴を取得
        /// </summary>
        /// <param name="query">取得条件 (省略時はフィルタしない/ 最大500件)</param>
        Task<ApiResponse<UserTransactionsResponse>> GetTransactionsAsync(UserTransactionsRequest? query = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの統計情報を取得
        /// </summary>
        Task<ApiResponse<UserStatsResponse>> GetStatsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの入金
        /// </summary>
        /// <param name="request">入金情報</param>
        Task<ApiResponse<UserDepositResponse>> DepositAsync(UserDepositRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの出金
        /// </summary>
        /// <param name="request">出金情報</param>
        Task<ApiResponse<UserWithdrawResponse>> WithdrawAsync(UserWithdrawRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの送金
        /// </summary>
        /// <param name="request">送金情報</param>
        Task<ApiResponse<UserTransferResponse>> TransferAsync(UserTransferRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// くじを引く
        /// </summary>
        Task<ApiResponse<UserLotteryResponse>> DrawLotteryAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// くじの積立金を取得する
        /// </summary>
        Task<ApiResponse<LotteryBankResponse>> GetLotteryBankAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザを検索
        /// </summary>
        /// <remarks>検索結果からシステムユーザは除外されます</remarks>
        Task<ApiResponse<UserSearchResponse>> SearchUserAsync(UserSearchRequest? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 全お知らせの件数を取得
        /// </summary>
        Task<ApiResponse<NoticesCountResponse>> GetNoticesCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// お知らせの一覧を取得
        /// </summary>
        Task<ApiResponse<NoticesResponse>> GetNoticeListAsync(NoticesRequest? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// お知らせの詳細情報を取得
        /// </summary>
        Task<ApiResponse<NoticeDetailResponse>> GetNoticeDetailAsync(int noticeId, CancellationToken cancellationToken = default);
    }
}