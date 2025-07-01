using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Users.Me;

namespace Hjp.Api.Client
{
    public interface IUsersClient
    {
        Task<ApiResponse<UserResponse>> LoginAsync(string accessToken, CancellationToken cancellationToken = default);
    }
}