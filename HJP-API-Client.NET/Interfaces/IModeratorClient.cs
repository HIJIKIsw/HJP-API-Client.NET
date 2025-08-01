using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Moderator.Users;
using Hjp.Shared.Dto.Moderator.Users.AccessToken.Reset;
using Hjp.Shared.Dto.Moderator.Users.Lottery;
using Hjp.Shared.Dto.Moderator.Users.Register;
using Hjp.Shared.Dto.Moderator.Users.ServerActivityReward;
using Hjp.Shared.Dto.Moderator.Users.Transfer;

namespace Hjp.Api.Client.Interfaces
{
    public interface IModeratorClient
    {
        /// <summary>
        /// ユーザの残高を取得
        /// </summary>
        /// <param name="discordUserId">残高を取得するユーザのDiscordユーザID</param>
        Task<ApiResponse<ModeratorUserBalanceResponse>> GetUserBalanceAsync(ulong discordUserId, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザのくじを実行
        /// </summary>
        /// <param name="discordUserId">くじを実行するユーザのDiscordユーザID</param>
        /// <param name="request">リクエスト詳細</param>
        Task<ApiResponse<ModeratorUserLotteryResponse>> DrawUserLotteryAsync(ulong discordUserId, ModeratorUserLotteryRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザ登録
        /// </summary>
        /// <param name="request">登録ユーザ情報</param>
        Task<ApiResponse<ModeratorUserRegisterResponse>> RegisterUserAsync(ModeratorUserRegisterRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザのアクセストークンをリセット
        /// (既存の場合は再作成、なければ新規作成する)
        /// </summary>
        /// <param name="discordUserId">アクセストークンを生成するユーザのDiscordユーザID</param>
        Task<ApiResponse<ModeratorUserAccessTokenResetResponse>> ResetUserAccessTokenAsync(ulong discordUserId, ModeratorUserAccessTokenResetRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// サーバー活動報酬を入金
        /// </summary>
        /// <param name="discordUserId">入金するユーザのDiscordユーザID</param>
        /// <param name="request">入金情報</param>
        Task<ApiResponse<ModeratorServerActivityRewardResponse>> DepositServerActivityRewardAsync(ulong discordUserId, ModeratorServerActivityRewardRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザ間送金
        /// </summary>
        /// <param name="discordUserId">送金するユーザのDiscordユーザID</param>
        /// <param name="request">送金情報</param>
        Task<ApiResponse<ModeratorUserTransferResponse>> UserTransferAsync(ulong discordUserId, ModeratorUserTransferRequest request, CancellationToken cancellationToken = default);
    }
}