using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Moderator.Users.AccessToken.Reset;
using Hjp.Shared.Dto.Moderator.Users.Register;

namespace Hjp.Api.Client
{
    internal class ModeratorClient : IModeratorClient
    {
        private readonly ulong discordUserId;

        private readonly ApiClientInternal apiClientInternal;

        public ModeratorClient(ApiClientInternal apiClientInternal, ulong discordUserId)
        {
            this.apiClientInternal = apiClientInternal;
            this.discordUserId = discordUserId;
        }

        public async Task<ApiResponse<ModeratorUserRegisterResponse>> RegisterUserAsync(ModeratorUserRegisterRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<ModeratorUserRegisterResponse>(
                discordUserId: this.discordUserId,
                route: "moderator/users/register",
                body: request,
                query: null,
                cancellationToken: cancellationToken);
        }

        [Obsolete("Use ResetUserAccessTokenAsync instead.")]
        public async Task<ApiResponse<ModeratorUserAccessTokenResetResponse>> GetUserAccessTokenAsync(ulong discordUserId, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<ModeratorUserAccessTokenResetResponse>(
                discordUserId: this.discordUserId,
                route: $"moderator/users/{discordUserId}/access-token",
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<ModeratorUserAccessTokenResetResponse>> ResetUserAccessTokenAsync(ulong discordUserId, ModeratorUserAccessTokenResetRequest request, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<ModeratorUserAccessTokenResetResponse>(
                discordUserId: this.discordUserId,
                route: $"moderator/users/{discordUserId}/access-token/reset",
                body: request,
                query: null,
                cancellationToken: cancellationToken);
        }
    }
}