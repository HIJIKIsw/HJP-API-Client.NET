using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Moderator.Users.AccessToken.Reset;
using Hjp.Shared.Dto.Moderator.Users.Register;

namespace Hjp.Api.Client.Interfaces
{
    public interface IModeratorClient
    {
        /// <summary>
        /// ユーザ登録
        /// </summary>
        /// <param name="request">登録ユーザ情報</param>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithModeratorAsync"/> を実行してください</remarks>
        Task<ApiResponse<ModeratorUserRegisterResponse>> RegisterUserAsync(ModeratorUserRegisterRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザのアクセストークンを取得
        /// (既存の場合は再作成、なければ新規作成する)
        /// </summary>
        /// <param name="discordUserId">アクセストークンを生成するユーザのDiscordユーザID</param>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithModeratorAsync"/> を実行してください。</remarks>
        [Obsolete("Use ResetUserAccessTokenAsync instead")]
        Task<ApiResponse<ModeratorUserAccessTokenResetResponse>> GetUserAccessTokenAsync(ulong discordUserId, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザのアクセストークンをリセット
        /// (既存の場合は再作成、なければ新規作成する)
        /// </summary>
        /// <param name="discordUserId">アクセストークンを生成するユーザのDiscordユーザID</param>
        /// <remarks>先に <see cref="HjpApiClient.LoginWithModeratorAsync"/> を実行してください。</remarks>
        Task<ApiResponse<ModeratorUserAccessTokenResetResponse>> ResetUserAccessTokenAsync(ulong discordUserId, ModeratorUserAccessTokenResetRequest request, CancellationToken cancellationToken = default);
    }
}