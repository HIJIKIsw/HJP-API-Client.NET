using Hjp.Api.Client.Dto;

namespace Hjp.Api.Client.Utilities
{
    public static class JwtPayloadModelExtensions
    {
        public static bool IsExpired(this JwtPayloadModel payload, int bufferSeconds = 300)
        {
            var expiration = DateTimeOffset.FromUnixTimeSeconds(payload.Expiration);
            return expiration < DateTimeOffset.UtcNow.AddSeconds(-bufferSeconds);
        }
    }
}