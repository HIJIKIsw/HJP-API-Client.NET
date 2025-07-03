using Hjp.Api.Client.Dto;
using Hjp.Api.Client.Interfaces;
using Hjp.Api.Client.Internal;
using Hjp.Shared.Dto.Moderator.Users.AccessToken;
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

        public async Task<ApiResponse<ModeratorUserAccessTokenResponse>> GetUserAccessTokenAsync(ulong discordUserId, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.GetWithSignatureAsync<ModeratorUserAccessTokenResponse>(
                discordUserId: this.discordUserId,
                route: $"moderator/users/{discordUserId}/access-token",
                query: null,
                cancellationToken: cancellationToken);
        }

        public async Task<ApiResponse<ModeratorUserAccessTokenResponse>> ResetUserAccessTokenAsync(ulong discordUserId, CancellationToken cancellationToken = default)
        {
            return await this.apiClientInternal.PostWithSignatureAsync<ModeratorUserAccessTokenResponse>(
                discordUserId: this.discordUserId,
                route: $"moderator/users/{discordUserId}/access-token/reset",
                body: null!,
                query: null,
                cancellationToken: cancellationToken);
        }
    }
}