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

namespace Hjp.Api.Client.Interfaces
{
    public interface IUsersClient
    {
        /// <summary>
        /// ユーザ情報を取得
        /// </summary>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<UserResponse>> GetProfileAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの残高を取得
        /// </summary>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<UserBalanceResponse>> GetBalanceAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの取引履歴を取得
        /// </summary>
        /// <param name="query">取得条件 (省略時はフィルタしない/ 最大500件)</param>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<UserTransactionsResponse>> GetTransactionsAsync(UserTransactionsRequest? query = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの統計情報を取得
        /// </summary>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<UserStatsResponse>> GetStatsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの入金
        /// </summary>
        /// <param name="request">入金情報</param>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<UserDepositResponse>> DepositAsync(UserDepositRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの出金
        /// </summary>
        /// <param name="request">出金情報</param>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<UserWithdrawResponse>> WithdrawAsync(UserWithdrawRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの送金
        /// </summary>
        /// <param name="request">送金情報</param>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<UserTransferResponse>> TransferAsync(UserTransferRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// くじを引く
        /// </summary>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<UserLotteryResponse>> DrawLotteryAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// くじの積立金を取得する
        /// </summary>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<LotteryBankResponse>> GetLotteryBankAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザを検索
        /// </summary>
        /// <remarks>
        /// 先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください
        /// 検索結果からシステムユーザは除外されます
        /// </remarks>
        Task<ApiResponse<UserSearchResponse>> SearchUserAsync(UserSearchRequest? request = null, CancellationToken cancellationToken = default);
    }
}