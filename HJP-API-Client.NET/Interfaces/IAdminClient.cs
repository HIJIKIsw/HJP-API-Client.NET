using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Admin.Transactions;
using Hjp.Shared.Dto.Admin.Users;
using Hjp.Shared.Dto.Admin.Users.Deposit;
using Hjp.Shared.Dto.Admin.Users.Withdraw;

namespace Hjp.Api.Client.Interfaces
{
    public interface IAdminClient
    {
        /// <summary>
        /// ユーザ情報を取得
        /// </summary>
        /// <param name="discordUserId">取得対象DiscordユーザID</param>
        /// <remarks>先に <see cref="IAdminClient.GetUserProfileAsync(string, CancellationToken)"/> を実行してください</remarks>
        Task<ApiResponse<AdminUserResponse>> GetUserProfileAsync(ulong discordUserId, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの入金
        /// </summary>
        /// <param name="discordUserId">入金対象DiscordユーザID</param>
        /// <param name="request">入金情報</param>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<AdminUserDepositResponse>> UserDepositAsync(ulong discordUserId, AdminUserDepositRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザの出金
        /// </summary>
        /// <param name="discordUserId">出金対象DiscordユーザID</param>
        /// <param name="request">出金情報</param>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithUserAsync"/> を実行してください</remarks>
        Task<ApiResponse<AdminUserWithdrawResponse>> UserWithdrawAsync(ulong discordUserId, AdminUserWithdrawRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 取引情報を取得
        /// </summary>
        /// <param name="request">取得フィルタ条件</param>
        Task<ApiResponse<AdminTransactionsResponse>> GetTransactionsAsync(AdminTransactionsRequest request, CancellationToken cancellationToken = default);
    }
}