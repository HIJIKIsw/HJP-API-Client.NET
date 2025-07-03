using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Moderator.Users.AccessToken;
using Hjp.Shared.Dto.Moderator.Users.Register;

namespace Hjp.Api.Client.Interfaces
{
    public interface IModeratorClient
    {
        /// <summary>
        /// ユーザ登録
        /// </summary>
        /// <param name="request">登録ユーザ情報</param>
        Task<ApiResponse<ModeratorUserRegisterResponse>> RegisterUserAsync(ModeratorUserRegisterRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザのアクセストークンを取得
        /// </summary>
        /// <param name="discordUserId">アクセストークンを生成するユーザのDiscordユーザID</param>
        /// <remarks>既存の場合は取得、なければ新規作成する</remarks>
        Task<ApiResponse<ModeratorUserAccessTokenResponse>> GetUserAccessTokenAsync(ulong discordUserId, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザのアクセストークンをリセット
        /// </summary>
        /// <param name="discordUserId">アクセストークンを生成するユーザのDiscordユーザID</param>
        /// <remarks>既存の場合は再作成、なければ新規作成する</remarks>
        Task<ApiResponse<ModeratorUserAccessTokenResponse>> ResetUserAccessTokenAsync(ulong discordUserId, CancellationToken cancellationToken = default);
    }
}