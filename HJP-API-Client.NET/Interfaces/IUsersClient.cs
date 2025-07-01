using Hjp.Api.Client.Dto;
using Hjp.Shared.Dto.Users.Login;

namespace Hjp.Api.Client
{
    public interface IUsersClient
    {
        Task<ApiResponse<UserLoginResponse>> LoginAsync(string accessToken, CancellationToken cancellationToken = default);
    }
}