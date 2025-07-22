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
        Task<ApiResponse<ModeratorUserRegisterResponse>> RegisterUserAsync(ModeratorUserRegisterRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// ユーザのアクセストークンをリセット
        /// (既存の場合は再作成、なければ新規作成する)
        /// </summary>
        /// <param name="discordUserId">アクセストークンを生成するユーザのDiscordユーザID</param>
        Task<ApiResponse<ModeratorUserAccessTokenResetResponse>> ResetUserAccessTokenAsync(ulong discordUserId, ModeratorUserAccessTokenResetRequest request, CancellationToken cancellationToken = default);
    }
}